using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
internal sealed class TicketCreatedDomainEventHandler : IDomainEventHandler<TicketCreatedDomainEvent>
{

    public TicketCreatedDomainEventHandler()
    {

    }

    public Task Handle(TicketCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}


