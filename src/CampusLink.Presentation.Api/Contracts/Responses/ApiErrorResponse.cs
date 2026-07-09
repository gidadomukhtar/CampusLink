namespace CampusLink.Presentation.Api.Contracts.Responses;

/// <summary>
/// Represents a standardized API error response contract.
/// </summary>
public sealed record ApiErrorResponse(
    string Code,
    string Message,
    string TraceId);
