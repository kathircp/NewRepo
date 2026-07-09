namespace WebApiApp.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception message)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var problemDetails = new
            {
                Status = context.Response.StatusCode,
                Title = "An unexpected error occurred.",
                Detail = message.Message
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
