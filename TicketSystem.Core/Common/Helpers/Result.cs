using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Helpers.Errors;

namespace TicketSystem.Domain.Common.Helpers;
public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));

        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);




}
public class Result<TValue> where TValue : notnull
{
    protected internal Result(TValue value, bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None||value is null)
        {
            throw new ArgumentException("Invalid error", nameof(error));

        }
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }
    public bool IsSuccess { get; }
    public TValue Value { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
}