using MediatR;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class TicketUpdatedDomainEventHandler(Guid Id, Guid TicketId) :
    INotificationHandler<TicketUpdatedDomainEvent>
{
    public Task Handle(TicketUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

