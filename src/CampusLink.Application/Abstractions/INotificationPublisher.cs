namespace CampusLink.Application.Abstractions;

/// <summary>
/// Defines a notification abstraction for post-processing events.
/// </summary>
public interface INotificationPublisher
{
    /// <summary>
    /// Publishes a notification that a lost item report was created.
    /// </summary>
    /// <param name="reportId">New report identifier.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>A task representing asynchronous execution.</returns>
    Task PublishLostItemReportCreatedAsync(Guid reportId, CancellationToken cancellationToken);
}
