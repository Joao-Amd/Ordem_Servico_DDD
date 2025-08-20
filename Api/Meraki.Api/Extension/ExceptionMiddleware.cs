using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Meraki.Api.Extension
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado capturado pelo middleware.");
                await _handleExceptionAsync(context, ex);
            }
        }

        private Task _handleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                ArgumentException => HttpStatusCode.BadRequest,
                ValidationException => HttpStatusCode.BadRequest,
                KeyNotFoundException => HttpStatusCode.NotFound,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = statusCode == HttpStatusCode.InternalServerError
                    ? "Ocorreu um erro inesperado. Tente novamente mais tarde."
                    : exception.Message,
                ExceptionType = exception.GetType().Name
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }

    }
}
