using MediatR;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class CommentCreatedDomainEventHandler(Guid Id, Guid CommentId)
    : INotificationHandler<CommentCreatedDomainEvent>
{
    public Task Handle(CommentCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
};

