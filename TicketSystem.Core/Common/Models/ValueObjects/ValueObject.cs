using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Common.Models.ValueObjects;
public abstract class ValueObject :  IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();
    public DateTime CreatedAt { get; set; }= DateTime.Now;
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        var valueObject = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }
    public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);
    public static bool operator !=(ValueObject left, ValueObject right) => !Equals(left, right);
    public override int GetHashCode() => GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
    public bool Equals(ValueObject? other) => Equals((object?)other);
}
