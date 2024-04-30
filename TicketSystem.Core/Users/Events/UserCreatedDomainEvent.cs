using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Users.Events;
public record UserCreatedDomainEvent(Guid Id, UserId UserId) : IEvent;

