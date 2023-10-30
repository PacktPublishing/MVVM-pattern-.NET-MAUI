using System.Diagnostics.CodeAnalysis;

namespace Recipes.Client.Core;

public sealed class Result<TSuccess>
{
    [MemberNotNullWhen(returnValue: true, member: nameof(Data))]
    [MemberNotNullWhen(returnValue: false, member: nameof(ErrorCode))]
    [MemberNotNullWhen(returnValue: false, member: nameof(ErrorData))]
    public bool IsSuccess { get; }

    public TSuccess? Data { get; }
    public string? ErrorCode { get; }
    public string? ErrorData { get; }
    public Exception? Exception { get; }

    private Result(TSuccess? data, string? errorCode, string? errorData, Exception? exception, bool isSuccess)
    {
        Data = data;
        ErrorCode = errorCode;
        ErrorData = errorData;
        Exception = exception;
        IsSuccess = isSuccess;
    }

    public static Result<TSuccess> Success(TSuccess data)
        => new Result<TSuccess>(data, null, null, null, true);

    public static Result<TSuccess> Success()
        => new Result<TSuccess>(default, null, null, null, true);

    public static Result<TSuccess> Fail(string errorCode, string? errorData = null, Exception? exception = null)
        => new Result<TSuccess>(default, errorCode, errorData, exception, false);

    public static Result<TSuccess> Fail(Exception exception)
        => new Result<TSuccess>(default, nameof(exception), exception.Message, exception, false);
}