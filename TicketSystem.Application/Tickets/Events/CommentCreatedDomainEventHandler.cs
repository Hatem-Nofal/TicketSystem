using MediatR;
using TicketSystem.Domain.Tickets.Events;

namespace TicketSystem.Application.Tickets.Events;
public sealed class CommentCreatedDomainEventHandler(Guid CommentId)
    : INotificationHandler<CommentCreatedDomainEvent>
{
    public Task Handle(CommentCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
};

