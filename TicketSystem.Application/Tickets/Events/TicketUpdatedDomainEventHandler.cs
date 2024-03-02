using MediatR;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
public sealed class TicketUpdatedDomainEventHandler(Guid TicketId) :
    INotificationHandler<TicketUpdatedDomainEvent>
{
    public Task Handle(TicketUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

