﻿using TicketSystem.Application.Interfaces.Base;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
internal sealed class TicketCreatedDomainEventHandler : IDomainEventHandler<TicketCreatedDomainEvent>
{


    public Task Handle(TicketCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}


