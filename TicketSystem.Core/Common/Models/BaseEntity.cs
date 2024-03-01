using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Common.Models;

public abstract class BaseEntity
{

    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.ToList();
    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();


}