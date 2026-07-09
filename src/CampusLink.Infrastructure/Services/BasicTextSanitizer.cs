using CampusLink.Application.Abstractions;

namespace CampusLink.Infrastructure.Services;

/// <summary>
/// Sanitizes text by trimming and removing control characters.
/// </summary>
public sealed class BasicTextSanitizer : ITextSanitizer
{
    /// <inheritdoc/>
    public string Sanitize(string input)
    {
        var chars = input.Where(c => !char.IsControl(c)).ToArray();
        return new string(chars).Trim();
    }
}
