namespace WebApiApp.Middleware
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Add a custom header to the response
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("X-Custom-Header", "CustomHeaderValue");
                return Task.CompletedTask;
            });
            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
