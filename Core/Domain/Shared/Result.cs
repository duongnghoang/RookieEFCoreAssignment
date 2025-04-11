namespace Domain.Shared;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    public static Result Success() => new(true, string.Empty);
    public static Result Failure(string error) => new(false, error);
    public static Result<T> Success<T>(T data) => new(true, data, string.Empty);
    public static Result<T> Failure<T>(string error) => new(false, default!, error);

}

public class Result<T> : Result
{
    public T Data { get; }
    public Result(bool isSuccess, T data, string error) : base(isSuccess, error)
    {
        Data = data;
    }
}