using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets.Events;
public record CommentCreatedDomainEvent(Guid Id, CommentId CommentId) : DomainEvent;

