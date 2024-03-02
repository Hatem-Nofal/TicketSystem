using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Tickets.Events;
public sealed record CommentCreatedDomainEvent(Guid CommentId) : IDomainEvent;

