using MediatR;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets.Events.EventsHandlers;
public sealed class TicketUpdatedDomainEventHandler(Guid Id, TicketId TicketId) :
    INotificationHandler<CommentCreatedDomainEvent>
{
    public Task Handle(CommentCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

