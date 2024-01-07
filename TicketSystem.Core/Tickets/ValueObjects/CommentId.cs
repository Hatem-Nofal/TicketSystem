using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;
using TicketSystem.Domain.Users.ValueObjects;

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
        throw new NotImplementedException();
    }
}
