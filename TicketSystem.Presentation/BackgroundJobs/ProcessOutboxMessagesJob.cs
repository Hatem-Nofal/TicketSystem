using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Infrastructure.Context;
using TicketSystem.Presentation.Outbox;

namespace TicketSystem.Presentation.BackgroundJobs;
public class ProcessOutboxMessagesJob : IJob
{
    private readonly TicketSystemDbContext _dbContext;
    private readonly IPublisher _publisher;

    public ProcessOutboxMessagesJob(TicketSystemDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        List<OutboxMessage> messages = await _dbContext.Set<OutboxMessage>()
            .Where(x => x.ProcessedOnUtc == null)
            .Take(1..20).ToListAsync(context.CancellationToken);
        foreach (OutboxMessage message in messages)
        {
            DomainEvent? domainEvent = JsonConvert
                .DeserializeObject<DomainEvent>(message.Content);
            if (domainEvent is null)
            {
                continue;
            }
            await _publisher.Publish(domainEvent, context.CancellationToken);
            message.ProcessedOnUtc = DateTime.UtcNow;

        }
        await _dbContext.SaveChangesAsync();
    }
}
