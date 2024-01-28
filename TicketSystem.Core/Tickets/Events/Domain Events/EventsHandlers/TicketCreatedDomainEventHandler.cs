using MediatR;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class TicketCreatedDomainEventHandler(Guid Id, TicketId TicketId) :
    INotificationHandler<TicketCreatedDomainEvent>
{
    public Task Handle(TicketCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

