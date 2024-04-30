using TicketSystem.Application.Core.Messaging;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
internal sealed class TicketCreatedDomainEventHandler
    : IEventHandler<TicketCreatedDomainEvent>
{

    public TicketCreatedDomainEventHandler()
    {

    }

    public Task Handle(TicketCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}


