 namespace SocialSync.Application.Common.Responses;
 
 public class CommonResponse<T>
    {
        public bool IsSuccess { get; set; }

        public object Error { get; set; }

        public T Value { get; set; }

        public string Message { get; set; }

        public static CommonResponse<T> Success(T value) =>
            new() { Value = value, IsSuccess = true };

        public static CommonResponse<T> Failure(string message) =>
            new() { Message = message, IsSuccess = false };

        public static CommonResponse<T> FailureWithError(string message, object error) =>
            new()
            {
                Message = message,
                Error = error,
                IsSuccess = false
            };
    }