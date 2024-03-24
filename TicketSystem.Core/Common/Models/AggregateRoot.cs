namespace TicketSystem.Domain.Common.Models;
public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull, BaseEntity
{
    protected AggregateRoot(TId id) : base(id)
    {
    }


}
