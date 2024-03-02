using MediatR;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
public sealed class CommentUpdatedDomainEventHandler(Guid CommentId) :
    INotificationHandler<CommentUpdatedDomainEvent>
{
    public Task Handle(CommentUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

