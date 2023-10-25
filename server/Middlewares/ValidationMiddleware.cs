using server.Models;
using System.Text.Json;

namespace server.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
                await _next(context);

        }
    }
}
