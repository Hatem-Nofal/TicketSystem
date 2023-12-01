using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;

namespace TicketSystem.Domain.Tickets.ValueObjects;
public sealed class TicketId : ValueObject
{
    public Guid Value { get;   }

    private TicketId(Guid value)
    {
        Value = value;
    }

    public static TicketId CreateUnique()=> new TicketId(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
