using CampusLink.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CampusLink.Application.DependencyInjection;

/// <summary>
/// Registers application-layer dependencies.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds application services.
    /// </summary>
    /// <param name="services">Target service collection.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILostItemReportService, LostItemReportService>();

        return services;
    }
}
