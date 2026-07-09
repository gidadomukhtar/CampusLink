using CampusLink.Application.DTOs;

namespace CampusLink.Application.Services;

/// <summary>
/// Provides use-cases for managing lost item reports.
/// </summary>
public interface ILostItemReportService
{
    /// <summary>
    /// Creates a new lost item report.
    /// </summary>
    /// <param name="command">Input command.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>Created report details.</returns>
    Task<LostItemReportDto> CreateAsync(CreateLostItemReportCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a report by identifier.
    /// </summary>
    /// <param name="reportId">Report identifier.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>Report details when found; otherwise null.</returns>
    Task<LostItemReportDto?> GetByIdAsync(Guid reportId, CancellationToken cancellationToken);
}
