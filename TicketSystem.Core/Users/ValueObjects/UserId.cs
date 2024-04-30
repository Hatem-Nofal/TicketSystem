using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Primitives.ValueObjects;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Users.ValueObjects;
[ComplexType]
 public sealed class UserId : ValueObject
{
    public Guid Value { get; }
    private UserId(){ }
    private UserId(Guid value) => Value = value;


    public static UserId CreateUnique() => new UserId(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    public static UserId Create(Guid Value) => new UserId(Value);
}
