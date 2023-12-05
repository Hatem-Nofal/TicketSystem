using Microsoft.EntityFrameworkCore;
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
[Owned]
public sealed record Email
{
    protected Email(string value) => Value = value;
    private Email() { }
    public string Value { get; }

    public static Result<Email> Create(string? email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return Result.Failure<Email>(EmailErrors.Empty);
        }
        if (IsValidEmail(email))
        {
            return Result.Failure<Email>(EmailErrors.InvalidFormate);
        }

        return Result.Success(new Email(email));

    }
    private static bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }
}
