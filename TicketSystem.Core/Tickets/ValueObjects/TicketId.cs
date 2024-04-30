using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Primitives.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;
[ComplexType]
public sealed class TicketId : ValueObject
{
     public Guid Value { get;}

    private TicketId() { }

 
    private TicketId(Guid value) => Value = value;

    public static TicketId CreateUnique()=> new TicketId(Guid.NewGuid());
    public static TicketId Create(Guid Value) => new TicketId(Value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
