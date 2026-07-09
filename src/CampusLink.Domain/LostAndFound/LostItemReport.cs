using CampusLink.Domain.Common;
using CampusLink.Domain.Exceptions;

namespace CampusLink.Domain.LostAndFound;

/// <summary>
/// Represents a lost item report submitted by a student.
/// </summary>
public sealed class LostItemReport
{
    private LostItemReport(Guid id, string title, string description, string contactEmail, string campus, DateTimeOffset createdUtc)
    {
        Id = id;
        Title = title;
        Description = description;
        ContactEmail = contactEmail;
        Campus = campus;
        CreatedUtc = createdUtc;
    }

    /// <summary>
    /// Gets the report identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets the report title.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the report description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the contact email.
    /// </summary>
    public string ContactEmail { get; }

    /// <summary>
    /// Gets the campus code or display name.
    /// </summary>
    public string Campus { get; }

    /// <summary>
    /// Gets the creation timestamp in UTC.
    /// </summary>
    public DateTimeOffset CreatedUtc { get; }

    /// <summary>
    /// Creates a validated lost-item report instance.
    /// </summary>
    /// <param name="title">Report title.</param>
    /// <param name="description">Report description.</param>
    /// <param name="contactEmail">Contact email address.</param>
    /// <param name="campus">Campus identifier.</param>
    /// <param name="createdUtc">UTC creation time.</param>
    /// <returns>A validated <see cref="LostItemReport"/> instance.</returns>
    /// <exception cref="DomainRuleViolationException">Thrown when a domain rule is violated.</exception>
    public static LostItemReport Create(
        string title,
        string description,
        string contactEmail,
        string campus,
        DateTimeOffset createdUtc)
    {
        var normalizedTitle = Guard.MaxLength(Guard.NotNullOrWhiteSpace(title, nameof(title)), 120, nameof(title));
        var normalizedDescription = Guard.MaxLength(Guard.NotNullOrWhiteSpace(description, nameof(description)), 1000, nameof(description));
        var normalizedEmail = Guard.MaxLength(Guard.NotNullOrWhiteSpace(contactEmail, nameof(contactEmail)), 255, nameof(contactEmail));
        var normalizedCampus = Guard.MaxLength(Guard.NotNullOrWhiteSpace(campus, nameof(campus)), 100, nameof(campus));

        if (!normalizedEmail.Contains('@'))
        {
            throw new DomainRuleViolationException("A valid contact email is required.");
        }

        return new LostItemReport(Guid.NewGuid(), normalizedTitle, normalizedDescription, normalizedEmail, normalizedCampus, createdUtc);
    }
}
