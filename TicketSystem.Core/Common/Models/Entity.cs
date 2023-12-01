using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Primitives;

namespace TicketSystem.Domain.Common.Models;
public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    public TId Id { get; protected set; }
    public Guid CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? ModifierId { get; set; }

    private readonly List<DomainEvent > _domainEvents = new();
 
  

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();

    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }
    public List<DomainEvent > DomainEvents => _domainEvents.ToList();
    protected void Raise(DomainEvent  domainEvent)
    {

        _domainEvents.Add(domainEvent);
    }
}
