using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Tickets.Events;
public sealed record TicketCreatedDomainEvent(Guid TicketId) : IDomainEvent;

