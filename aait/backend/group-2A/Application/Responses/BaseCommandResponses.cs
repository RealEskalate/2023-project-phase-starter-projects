using Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Application.Responses
{
    public class BaseCommandResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Value { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; } = 200;

        public static BaseCommandResponse<T> SuccessHandler(T value)
        {
            return new BaseCommandResponse<T> { Success = true, Value = value };
        }

        public static BaseCommandResponse<T> FailureHandler(Exception exception)
        {
            var response = new BaseCommandResponse<T> { Success = false };

            if (exception is ValidationException validationException)
            {
                response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                response.Errors = validationException.Errors;
            }
            else if (exception is BadRequestException badRequestException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Errors = new List<string> { badRequestException.Message };
            }
            else if (exception is NotFoundException notFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Errors = new List<string> { notFoundException.Message };
            }
            else if (exception is ServerErrorException server)
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Errors = new List<string> { server.Message };
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Errors = new List<string> { $"Internal Server Error{exception}" };
            }

            return response;
        }
    }
}
