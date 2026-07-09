using System.Collections.Concurrent;
using CampusLink.Application.Abstractions;
using CampusLink.Domain.LostAndFound;

namespace CampusLink.Infrastructure.Repositories;

/// <summary>
/// Provides in-memory persistence for lost item reports.
/// </summary>
public sealed class InMemoryLostItemReportRepository : ILostItemReportRepository
{
    private readonly ConcurrentDictionary<Guid, LostItemReport> _store = new();

    /// <inheritdoc/>
    public Task AddAsync(LostItemReport report, CancellationToken cancellationToken)
    {
        _store[report.Id] = report;
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task<LostItemReport?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _store.TryGetValue(id, out var report);
        return Task.FromResult(report);
    }
}
