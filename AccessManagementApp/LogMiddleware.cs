
using AccessManagementApp.Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AccessManagementApp
{
    public class LogMiddleware : IMiddleware
    {
        private readonly ICustomLogger _logger = SingletonLogger.GetInstance();
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                _logger.Log($"Catch exception in path: {context.Request.Path}. Exception message: {ex.Message}");
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error",
                    Detail = ex.Message
                };

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
