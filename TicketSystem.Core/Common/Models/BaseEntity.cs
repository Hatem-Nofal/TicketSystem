using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Common.Models;

public abstract class BaseEntity
{
    private readonly List<IEvent> _domainEvents = new();

    public IReadOnlyList<IEvent> DomainEvents => _domainEvents.ToList();
    protected void Raise(IEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();




}