using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Shared.Models.Outbox;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Presentation.Interceptors;
public sealed class OutboxMessageInterceptor : SaveChangesInterceptor
{

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
       DbContextEventData eventData,
       InterceptionResult<int> result,
       CancellationToken cancellationToken = default)
    {
        DbContext dbContext = eventData.Context;

        if (dbContext is not null)
        {
            await InsertInOutboxMessages(dbContext);
        }
        var res = await base.SavingChangesAsync(eventData, result, cancellationToken);
        dbContext.ChangeTracker.Entries<BaseEntity>()
               .Select(x => x.Entity)
               .SelectMany(e =>
               {
                   List<DomainEvent> domainEvents = e.DomainEvents.ToList();
                   e.ClearDomainEvents();
                   return domainEvents;
               });
        return res;
    }


    private static async Task InsertInOutboxMessages(DbContext dbContext)
    {

        DateTime utcNow = DateTime.UtcNow;
        var outboxMessages = dbContext.ChangeTracker.Entries<BaseEntity>()
                .Select(x => x.Entity)
                .SelectMany(e =>
                {
                    List<DomainEvent> domainEvents = e.DomainEvents.ToList();
                    return domainEvents;
                }).Select(domainEvent => new OutboxMessage
                {
                    Id = domainEvent.Id,
                    OccuredOnUtc = utcNow,
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(domainEvent
                    , new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All

                    }
                    )
                })
                .ToList();
        await dbContext.Set<OutboxMessage>().AddRangeAsync(outboxMessages);
    }
}
