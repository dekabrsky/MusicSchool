using System;
using Microsoft.EntityFrameworkCore;
using MusicSchoolModel.Core.Domain.Common.ValueObjects;

[Owned]
public class PersonName
{
    protected PersonName() { }

    public PersonName(Name firstName, Name lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    public Name FirstName { get; }
    public Name LastName { get; }

    public string FullName => $"{FirstName.Value} {LastName.Value}";

    public override bool Equals(object obj)
    {
        return obj is PersonName personalName &&
               FirstName.Equals(personalName.FirstName) &&
               LastName.Equals(personalName.LastName) &&
               FullName.Equals(personalName.FullName);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, FullName);
    }

    public override string ToString()
    {
        return FullName;
    }
}