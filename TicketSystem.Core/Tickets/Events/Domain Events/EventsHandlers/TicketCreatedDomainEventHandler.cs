using MediatR;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class TicketCreatedDomainEventHandler(Guid Id, Guid TicketId) :
    INotificationHandler<TicketCreatedDomainEvent>
{
    public Task Handle(TicketCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

