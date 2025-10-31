using task_manager.Communications.Responses;

namespace task_manager.Communications.Result
{
    public class Result<T>(bool success, T? data, ResponseErrorsJson? error)
    {
        public bool Success { get; } = success;
        public ResponseErrorsJson? ErrorMessage { get; } = error;
        public T? Data { get; } = data;

        public static Result<T> Ok(T data) => new Result<T>(true, data, null);
        public static Result<T> Fail(ResponseErrorsJson error) => new Result<T>(false, default, error);
    }
}
