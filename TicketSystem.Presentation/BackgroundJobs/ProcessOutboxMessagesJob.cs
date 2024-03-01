using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Models.Outbox;
using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Infrastructure.Context;

namespace TicketSystem.Presentation.BackgroundJobs;
public class ProcessOutboxMessagesJob : IprocessOutboxMessagesJob
{
    private readonly TicketSystemDbContext _dbContext;
    private readonly IPublisher _publisher;

    public ProcessOutboxMessagesJob()
    {

    }
    public ProcessOutboxMessagesJob(TicketSystemDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task Execute(CancellationToken cancellationToken = default)
    {
        try
        {
            List<OutboxMessage> messages = await _dbContext.Set<OutboxMessage>()
              .Where(x => x.ProcessedOnUtc == null)
              .Take(20).ToListAsync(cancellationToken);
            foreach (OutboxMessage message in messages)
            {
                IDomainEvent? domainEvent = JsonConvert
                    .DeserializeObject<IDomainEvent>(message.Content, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All

                    });
                if (domainEvent is null)
                {
                    continue;
                }

                try
                {

                    await _publisher.Publish(domainEvent, cancellationToken);

                }
                catch (Exception ex)
                {

                    throw;
                }
                message.ProcessedOnUtc = DateTime.UtcNow;

            }
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {

            throw;
        }
    }
}
