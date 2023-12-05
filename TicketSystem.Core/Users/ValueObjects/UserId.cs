using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;
using TicketSystem.Domain.Tickets.ValueObjects;

namespace TicketSystem.Domain.Users.ValueObjects;
public sealed class UserId : ValueObject
{
    public Guid Value { get;   }
  
    private UserId(Guid value)=>Value = value;
 

    public static UserId CreateUnique()=> new UserId(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
    public static UserId Create(Guid Value)
    {
        return new UserId(Value);
    }
}
