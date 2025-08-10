    using System.Net;

namespace NileRoutes.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                _logger.LogError(ex, $"{errorId} : {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Id = errorId,
                    ErrorMessage = "An unexpected error occurred. Please try again later."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
