using System;

namespace MusicSchoolModel.Core.Domain.Common.ValueObjects;

public class Name
{
    public string Value { get; }

    protected Name(){}

    public Name(string name)
    {
        if (!IsValid(name))
        {
            throw new ArgumentException("Name isn't valid");
        }

        Value = name;
    }

    public static bool IsValid(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public override bool Equals(Object obj)
    {
        return obj is Name other && StringComparer.Ordinal.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(Value);
    }
}