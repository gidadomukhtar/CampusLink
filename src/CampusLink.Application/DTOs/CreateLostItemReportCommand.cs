namespace CampusLink.Application.DTOs;

/// <summary>
/// Represents the command used to create a lost item report.
/// </summary>
/// <param name="Title">Report title.</param>
/// <param name="Description">Report details.</param>
/// <param name="ContactEmail">Contact email.</param>
/// <param name="Campus">Campus identifier.</param>
public sealed record CreateLostItemReportCommand(
    string Title,
    string Description,
    string ContactEmail,
    string Campus);
