using CampusLink.Application.Abstractions;
using Microsoft.Extensions.Logging;

namespace CampusLink.Infrastructure.Services;

/// <summary>
/// Represents a no-op notification publisher extension point.
/// </summary>
public sealed class NoOpNotificationPublisher : INotificationPublisher
{
    private readonly ILogger<NoOpNotificationPublisher> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="NoOpNotificationPublisher"/> class.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public NoOpNotificationPublisher(ILogger<NoOpNotificationPublisher> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc/>
    public Task PublishLostItemReportCreatedAsync(Guid reportId, CancellationToken cancellationToken)
    {
        _logger.LogDebug("No-op notification handler invoked for report {ReportId}", reportId);
        return Task.CompletedTask;
    }
}
