using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Responses;
using System.Net;

namespace WebApi.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                // Process the response and wrap it in the custom format
                var response = new BaseCommandResponse<object>
                {
                    Success = true,
                    Value = JsonSerializer.Deserialize<object>(await FormatResponse(context))
                };

                // Reset the stream position and write the modified response
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
        }

        private async Task<string> FormatResponse(HttpContext context)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(context.Response.Body);
            var text = await reader.ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            return text;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMiddleware>();
        }
    }
}
