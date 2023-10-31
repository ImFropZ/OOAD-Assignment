using server.Exceptions;

namespace server.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(StatusCodeException e) 
            {
                context.Response.Headers.Add("Content-Type", "application/json");
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsJsonAsync(new { message = e.Message });
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                if (e.InnerException is StatusCodeException ex)
                {
                    context.Response.Headers.Add("Content-Type", "application/json");
                    context.Response.StatusCode = ex.StatusCode;
                    await context.Response.WriteAsJsonAsync(new { message = ex.Message });
                    return;
                }

                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}