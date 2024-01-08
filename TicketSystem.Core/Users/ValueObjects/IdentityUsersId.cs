using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models.ValueObjects;

namespace TicketSystem.Domain.Users.ValueObjects;
public sealed class IdentityUsersId : ValueObject
{
    public Guid Value { get; }

    private IdentityUsersId(){}

    private IdentityUsersId(Guid value) => Value = value;

    public static IdentityUsersId Create(Guid Value) => new IdentityUsersId(Value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
