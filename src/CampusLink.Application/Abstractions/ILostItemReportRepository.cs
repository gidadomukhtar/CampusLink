using CampusLink.Domain.LostAndFound;

namespace CampusLink.Application.Abstractions;

/// <summary>
/// Defines persistence operations for lost item reports.
/// </summary>
public interface ILostItemReportRepository
{
    /// <summary>
    /// Saves a lost item report.
    /// </summary>
    /// <param name="report">Report to persist.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>A task representing asynchronous execution.</returns>
    Task AddAsync(LostItemReport report, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a report by identifier.
    /// </summary>
    /// <param name="id">Report identifier.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>Matching report if found; otherwise null.</returns>
    Task<LostItemReport?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
