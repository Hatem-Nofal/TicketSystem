using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Users.Events;
public sealed record UserCreatedDomainEvent(Guid Id, UserId UserId) : DomainEvent(Id);


