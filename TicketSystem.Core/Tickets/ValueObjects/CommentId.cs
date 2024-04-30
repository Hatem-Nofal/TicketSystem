using System.ComponentModel.DataAnnotations.Schema;
using TicketSystem.Domain.Primitives.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;
[ComplexType]
public sealed class CommentId : ValueObject
{
    public Guid Value { get; }

    private CommentId(Guid value) => Value = value;
    public static CommentId CreateUnique() => new CommentId(Guid.NewGuid());

    public static CommentId Create(Guid Value) => new CommentId(Value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
