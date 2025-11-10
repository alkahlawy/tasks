using DomainLayer.Exceptions;
using Shared.ErrorModels;
using System.Text.Json;
namespace TalabatDemo.CustomMiddleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<CustomExceptionHandlerMiddleware> logger
            )
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                await HandleNotFoundEndpoint(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionsAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionsAsync(HttpContext httpContext, Exception ex)
        {
            _logger.LogError(ex, $"Something went wrong");

            // Set status code and content type for the response
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            // Create a response object
            var response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message,
            };

            // Return a JSON response with the error details
            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private static async Task HandleNotFoundEndpoint(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var response = new ErrorToReturn()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = $"There is no endpoint with {httpContext.Request.Path} was found."
                };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
