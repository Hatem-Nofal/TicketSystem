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
            List<OutboxMessage> messages = await _dbContext
          .Set<OutboxMessage>()
          .Where(m => m.ProcessedOnUtc == null)
          .Take(20)
          .ToListAsync(cancellationToken);

            foreach (OutboxMessage outboxMessage in messages)
            {
                IDomainEvent? domainEvent = JsonConvert
                    .DeserializeObject<IDomainEvent>(
                        outboxMessage.Content,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        });

                if (domainEvent is null)
                {
                    continue;
                }

                await _publisher.Publish(domainEvent, cancellationToken);

                outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {

            throw;
        }
    }
}
