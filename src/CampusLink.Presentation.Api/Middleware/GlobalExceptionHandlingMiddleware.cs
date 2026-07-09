using System.Net;
using System.Text.Json;
using CampusLink.Application.Exceptions;
using CampusLink.Domain.Exceptions;
using CampusLink.Presentation.Api.Contracts.Responses;

namespace CampusLink.Presentation.Api.Middleware;

/// <summary>
/// Handles unhandled exceptions and converts them into API error contracts.
/// </summary>
public sealed class GlobalExceptionHandlingMiddleware
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionHandlingMiddleware"/> class.
    /// </summary>
    /// <param name="next">Next middleware delegate.</param>
    /// <param name="logger">Logger instance.</param>
    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes middleware logic.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    /// <returns>A task representing asynchronous execution.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception. TraceId: {TraceId}", context.TraceIdentifier);
            await WriteErrorResponseAsync(context, ex);
        }
    }

    private static async Task WriteErrorResponseAsync(HttpContext context, Exception exception)
    {
        var (statusCode, code, message) = exception switch
        {
            ApplicationValidationException validationException =>
                (HttpStatusCode.BadRequest, "validation_failed", validationException.Message),
            DomainRuleViolationException domainException =>
                (HttpStatusCode.UnprocessableEntity, "domain_rule_violation", domainException.Message),
            ArgumentException argumentException =>
                (HttpStatusCode.BadRequest, "invalid_argument", argumentException.Message),
            _ => (HttpStatusCode.InternalServerError, "unexpected_error", "An unexpected error occurred.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var contract = new ApiErrorResponse(code, message, context.TraceIdentifier);
        await context.Response.WriteAsync(JsonSerializer.Serialize(contract, JsonSerializerOptions));
    }
}
