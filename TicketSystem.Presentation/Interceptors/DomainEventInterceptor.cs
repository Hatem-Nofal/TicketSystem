using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Presentation.Outbox;

namespace TicketSystem.Presentation.Interceptors;
public sealed class DomainEventInterceptor : SaveChangesInterceptor
{
    public override ValueTask<int> SavedChangesAsync
        (SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        DbContext dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
        var outboxMessages = dbContext.ChangeTracker.Entries<BaseEntity>()
                  .Select(x => x.Entity)
                  .SelectMany(e =>
                  {
                      List<DomainEvent> domainEvents = e.DomainEvents.ToList();
                      e.ClearDomainEvents();
                      return domainEvents;
                  }).Select(domainEvent => new OutboxMessage
                  {
                      Id = Guid.NewGuid(),
                      OccuredOnUtc = DateTime.UtcNow,
                      Type = domainEvent.GetType().Name,
                      Content = JsonConvert.SerializeObject(domainEvent
                      , new JsonSerializerSettings
                      {
                          TypeNameHandling = TypeNameHandling.All

                      }
                      )
                  })
                  .ToList();
        dbContext.Set<OutboxMessage>().AddRange(outboxMessages);
        return base.SavedChangesAsync(eventData, result, cancellationToken);

    }
}
