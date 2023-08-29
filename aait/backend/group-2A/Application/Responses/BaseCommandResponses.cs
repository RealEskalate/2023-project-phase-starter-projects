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

        public  static BaseCommandResponse<T> SuccessHandler(T value)
        {
            var response = new BaseCommandResponse<T>();
            response.Success = true;
            response.Value = value;
            return response;
        }

        public static BaseCommandResponse<T> FailureHandler(Exception exception)
        {
            var response = new BaseCommandResponse<T>();
            response.Success = false;
            if (exception is ValidationException validationException)
            {
                response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                response.Errors = new List<string> { validationException.Message };
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
            else
            {
                var serverErrorException = new ServerErrorException("Internal Server Error");
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Errors = new List<string> { serverErrorException.Message };
            }

            return response;
        }
    }
}
