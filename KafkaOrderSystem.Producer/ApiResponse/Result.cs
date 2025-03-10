namespace KafkaOrderSystem.Producer.ApiResponse
{
    public class Result
    {
        private Result(bool isSuccess, object? data, Error error)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public object? Data { get; }

        public static Result Success(object? data = default) => new(true, data, Error.None);
        public static Result Failure(Error error) => new(false, default, error);
    }
}
