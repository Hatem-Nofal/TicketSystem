using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
{

    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumeration();
    public Enumeration(string name, int value)
    {

        Name = name;
        Value = value;
    }
    public int Value { get; protected init; }
    public string Name { get; protected init; } = string.Empty;

    public static TEnum? FromValue(int value)
    {
        return Enumerations.TryGetValue(value,out TEnum ? enumeration)? enumeration:default;

    }
    public static TEnum? FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Name == name);
    }
    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is Nullable)
        {
            return false;
        }

        return GetType() == other.GetType() && Value == other.Value;
    }
    public override bool Equals(object obj)
    {
        return obj is Enumeration<TEnum> other && Equals(other);
    }
    public override int GetHashCode()
    {
        return Value;
    }

    public override string ToString()
    {
        return Name;
    }
    private static Dictionary<int, TEnum> CreateEnumeration()
    {
        var enumerationType = typeof(TEnum);
        var fieldsForType = enumerationType
             .GetFields(
                BindingFlags.Public
                BindingFlags.Static
                BindingFlags.FlattenHierarchy).
         Where(fieldInfo =>
            enumerationType.IsAssignableFrom(fieldInfo.FieldType))
         .Select(fieldInfo =>
            (TEnum)fieldInfo.GetValue(default)!);
        return fieldsForType.ToDictionary(x=>x.Value);
    }
}

