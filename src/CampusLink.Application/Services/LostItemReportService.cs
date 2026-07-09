using CampusLink.Application.Abstractions;
using CampusLink.Application.DTOs;
using CampusLink.Application.Exceptions;
using CampusLink.Domain.Common;
using CampusLink.Domain.LostAndFound;
using Microsoft.Extensions.Logging;

namespace CampusLink.Application.Services;

/// <summary>
/// Implements lost-item report use cases.
/// </summary>
public sealed class LostItemReportService : ILostItemReportService
{
    private readonly ILostItemReportRepository _repository;
    private readonly ITextSanitizer _textSanitizer;
    private readonly INotificationPublisher _notificationPublisher;
    private readonly ILogger<LostItemReportService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="LostItemReportService"/> class.
    /// </summary>
    /// <param name="repository">Lost-item report repository.</param>
    /// <param name="textSanitizer">Text sanitizer.</param>
    /// <param name="notificationPublisher">Notification publisher.</param>
    /// <param name="logger">Application logger.</param>
    public LostItemReportService(
        ILostItemReportRepository repository,
        ITextSanitizer textSanitizer,
        INotificationPublisher notificationPublisher,
        ILogger<LostItemReportService> logger)
    {
        _repository = repository;
        _textSanitizer = textSanitizer;
        _notificationPublisher = notificationPublisher;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<LostItemReportDto> CreateAsync(CreateLostItemReportCommand command, CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new ApplicationValidationException("Request payload is required.");
        }

        var title = _textSanitizer.Sanitize(Guard.NotNullOrWhiteSpace(command.Title, nameof(command.Title)));
        var description = _textSanitizer.Sanitize(Guard.NotNullOrWhiteSpace(command.Description, nameof(command.Description)));
        var contactEmail = _textSanitizer.Sanitize(Guard.NotNullOrWhiteSpace(command.ContactEmail, nameof(command.ContactEmail)));
        var campus = _textSanitizer.Sanitize(Guard.NotNullOrWhiteSpace(command.Campus, nameof(command.Campus)));

        var report = LostItemReport.Create(title, description, contactEmail, campus, DateTimeOffset.UtcNow);

        await _repository.AddAsync(report, cancellationToken);
        await _notificationPublisher.PublishLostItemReportCreatedAsync(report.Id, cancellationToken);

        _logger.LogInformation(
            "Created lost item report {ReportId} for campus {Campus}",
            report.Id,
            report.Campus);

        return Map(report);
    }

    /// <inheritdoc/>
    public async Task<LostItemReportDto?> GetByIdAsync(Guid reportId, CancellationToken cancellationToken)
    {
        if (reportId == Guid.Empty)
        {
            throw new ApplicationValidationException("Report ID must be a non-empty GUID.");
        }

        var report = await _repository.GetByIdAsync(reportId, cancellationToken);

        return report is null ? null : Map(report);
    }

    private static LostItemReportDto Map(LostItemReport report) =>
        new(report.Id, report.Title, report.Description, report.ContactEmail, report.Campus, report.CreatedUtc);
}
