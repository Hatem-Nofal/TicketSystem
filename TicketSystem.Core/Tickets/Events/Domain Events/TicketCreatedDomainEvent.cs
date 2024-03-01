using TicketSystem.Domain.Common.Primitives;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Tickets.Events;
public record TicketCreatedDomainEvent(TicketId TicketId) : DomainEvent;

