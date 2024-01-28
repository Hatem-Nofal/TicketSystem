using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Common.Models;

public abstract class BaseEntity
{
    private readonly List<DomainEvent> _domainEvents = new();
    public List<DomainEvent> DomainEvents => _domainEvents.ToList();
    protected void Raise(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();


}