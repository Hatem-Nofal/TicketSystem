using MediatR;

namespace TicketSystem.Domain.Common.Primitives;
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent;
