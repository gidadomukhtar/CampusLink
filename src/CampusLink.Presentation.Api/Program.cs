using CampusLink.Application.DependencyInjection;
using CampusLink.Infrastructure.DependencyInjection;
using CampusLink.Presentation.Api.Extensions;
using CampusLink.Presentation.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();

var allowedOrigins = builder.Configuration
    .GetSection("Security:Cors:AllowedOrigins")
    .Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy =>
    {
        if (allowedOrigins.Length > 0)
        {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod();
            return;
        }

        policy.WithOrigins("https://localhost");
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("DefaultCors");
app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
