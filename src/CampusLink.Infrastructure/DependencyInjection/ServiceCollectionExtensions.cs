using CampusLink.Application.Abstractions;
using CampusLink.Infrastructure.Repositories;
using CampusLink.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CampusLink.Infrastructure.DependencyInjection;

/// <summary>
/// Registers infrastructure-layer dependencies.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds infrastructure services.
    /// </summary>
    /// <param name="services">Target service collection.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ILostItemReportRepository, InMemoryLostItemReportRepository>();
        services.AddSingleton<ITextSanitizer, BasicTextSanitizer>();
        services.AddScoped<INotificationPublisher, NoOpNotificationPublisher>();

        return services;
    }
}
