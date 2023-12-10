
using Microsoft.AspNetCore.Mvc;

namespace AccessManagementApp
{
    public class LogMiddleware : IMiddleware
    {
        private readonly Logger.ILogger _logger = Logger.Logger.Instance;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                _logger.Log(ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error",
                    Detail = $"Hello from Middleware: {ex.Message}"
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
