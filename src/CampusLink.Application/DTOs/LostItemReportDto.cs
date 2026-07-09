namespace CampusLink.Application.DTOs;

/// <summary>
/// Represents a lost item report transfer object.
/// </summary>
public sealed record LostItemReportDto(
    Guid Id,
    string Title,
    string Description,
    string ContactEmail,
    string Campus,
    DateTimeOffset CreatedUtc);
