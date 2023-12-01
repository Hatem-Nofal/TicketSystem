using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Helpers;
using TicketSystem.Domain.Common.Helpers.Errors;

namespace TicketSystem.Domain.Common.Models.ValueObjects;
public sealed record Phone
{
    private Phone(string value) => Value = value;

    public string Value { get; }

    public static Result<Phone> Create(string? phone)
    {
        if (string.IsNullOrEmpty(phone))
        {
            return Result.Failure<Phone>(PhoneErrors.Empty);
        }
        if (IsValidPhone(phone))
        {
            return Result.Failure<Phone>(PhoneErrors.InvalidFormate);
        }

        return Result.Success(new Phone(phone));

    }
    private static bool IsValidPhone(string phone)
    {
        // Pattern for Egyptian phone number
        string pattern = @"^\+20\s\d{1,2}\s\d{3}-\d{4}$";

        // Create a Regex object
        Regex regex = new Regex(pattern);

        // Check if the phone number matches the pattern
        return regex.IsMatch(phone);
    }
}
