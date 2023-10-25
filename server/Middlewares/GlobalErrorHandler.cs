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
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}