using System.Net;
using Sobczal.InPost.Application.Exceptions;

namespace Sobczal.InPost.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex).ConfigureAwait(false);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        if (exception is InPostException inPostException)
        {
            context.Response.StatusCode = (int)inPostException.HttpStatusCode;
            return;
        }
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    }
}