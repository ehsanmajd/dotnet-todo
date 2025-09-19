using System.Net;
using System.Text.Json;

namespace TodoList;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception
        _logger.LogError(exception, "An unhandled exception occurred");

        // Default error response
        var errorResponse = new ErrorResponse
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
            Message = "An unexpected error occurred",
            Details = null // Set to null in production, or include for development
        };

        // Customize response based on exception type
        switch (exception)
        {
            case NotFoundException customEx:
                errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                errorResponse.Message = customEx.Message;
                break;
                // Add more specific exception types as needed
        }

        // In development, include stack trace
#if DEBUG
        errorResponse.Details = exception.StackTrace;
#endif

        // Set the response
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorResponse.StatusCode;

        // Serialize and write response
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }
}