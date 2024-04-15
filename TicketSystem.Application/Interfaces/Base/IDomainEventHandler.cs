using MediatR;
using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Application.Interfaces.Base;


public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}