using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;

namespace TicketSystem.Domain.Users.ValueObjects;
public sealed class IdentityUsersId : ValueObject
{
    public Guid Value { get; }

    private IdentityUsersId()
    {

    }
    private IdentityUsersId(Guid value)
    {
        Value = value;
    }

    public static IdentityUsersId Create(Guid Value)
    {
        return new IdentityUsersId(Value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
