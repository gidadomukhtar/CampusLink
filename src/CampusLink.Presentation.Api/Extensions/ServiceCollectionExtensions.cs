using CampusLink.Presentation.Api.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CampusLink.Presentation.Api.Extensions;

/// <summary>
/// Registers presentation layer services and MVC options.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds presentation-level services.
    /// </summary>
    /// <param name="services">Target service collection.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var firstError = context.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => string.IsNullOrWhiteSpace(e.ErrorMessage) ? "Invalid request." : e.ErrorMessage)
                        .FirstOrDefault() ?? "Invalid request.";

                    return new BadRequestObjectResult(
                        new ApiErrorResponse(
                            "validation_failed",
                            firstError,
                            context.HttpContext.TraceIdentifier));
                };
            });

        services.AddEndpointsApiExplorer();
        services.AddAuthorization();

        return services;
    }
}
