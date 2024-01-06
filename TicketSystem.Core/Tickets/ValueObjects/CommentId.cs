using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;

namespace TicketSystem.Domain.Tickets.ValueObjects;
public sealed class CommentId : ValueObject
{
    public long Value { get; }

    private CommentId(long value)
    {
        Value = value;
    }

     public static CommentId Create(long Value)
    {
        return new CommentId(Value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
