using server.Error;

namespace server.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ServerError e)
            {
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsync(e.Message);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                context.Response.StatusCode = 500;
                return;
            }
        }
    }
}
