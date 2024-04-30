using TicketSystem.Application.Core.Messaging;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
public sealed class CommentUpdatedDomainEventHandler :
    IEventHandler<CommentUpdatedDomainEvent>
{
    public Task Handle(CommentUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

