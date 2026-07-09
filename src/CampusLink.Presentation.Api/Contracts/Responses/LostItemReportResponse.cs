namespace CampusLink.Presentation.Api.Contracts.Responses;

/// <summary>
/// Represents the lost-item report response payload.
/// </summary>
public sealed record LostItemReportResponse(
    Guid Id,
    string Title,
    string Description,
    string ContactEmail,
    string Campus,
    DateTimeOffset CreatedUtc);
