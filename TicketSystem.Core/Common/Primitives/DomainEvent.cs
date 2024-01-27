using MediatR;

namespace TicketSystem.Domain.Common.Primitives;
public record DomainEvent(Guid Id) : INotification;
