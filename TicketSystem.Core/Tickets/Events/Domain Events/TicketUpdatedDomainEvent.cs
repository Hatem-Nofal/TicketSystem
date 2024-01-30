using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Tickets.Events;
public sealed record TicketUpdatedDomainEvent(Guid Id, Guid TicketId) : DomainEvent(Id);

