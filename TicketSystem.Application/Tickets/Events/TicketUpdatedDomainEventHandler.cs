using TicketSystem.Application.Core.Messaging;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
public sealed class TicketUpdatedDomainEventHandler :
    IEventHandler<TicketUpdatedDomainEvent>
{
    public Task Handle(TicketUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

