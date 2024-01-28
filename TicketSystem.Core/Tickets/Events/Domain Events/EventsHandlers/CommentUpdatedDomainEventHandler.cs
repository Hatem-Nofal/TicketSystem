using MediatR;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class CommentUpdatedDomainEventHandler(Guid Id, CommentId CommentId) :
    INotificationHandler<CommentUpdatedDomainEvent>
{
    public Task Handle(CommentUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

