using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SocialMediaApp.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
           var exception = context.Exception;

            var errorResult = new { error = "an error occured while processing" };
            context.Result = new ObjectResult(errorResult)
            {
                StatusCode = 500  
            };
            context.ExceptionHandled = true;
        }
    }
}
