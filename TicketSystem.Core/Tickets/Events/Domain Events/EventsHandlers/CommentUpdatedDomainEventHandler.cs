using MediatR;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class CommentUpdatedDomainEventHandler(Guid Id, Guid CommentId) :
    INotificationHandler<CommentUpdatedDomainEvent>
{
    public Task Handle(CommentUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

