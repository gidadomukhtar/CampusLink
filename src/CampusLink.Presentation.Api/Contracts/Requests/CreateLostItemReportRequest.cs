using System.ComponentModel.DataAnnotations;

namespace CampusLink.Presentation.Api.Contracts.Requests;

/// <summary>
/// Represents the API request for creating a lost item report.
/// </summary>
public sealed class CreateLostItemReportRequest
{
    /// <summary>
    /// Gets or sets the report title.
    /// </summary>
    [Required]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the report description.
    /// </summary>
    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contact email.
    /// </summary>
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string ContactEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the campus.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Campus { get; set; } = string.Empty;
}
