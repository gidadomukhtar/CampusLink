namespace CampusLink.Application.Abstractions;

/// <summary>
/// Sanitizes user-provided text values before domain processing.
/// </summary>
public interface ITextSanitizer
{
    /// <summary>
    /// Sanitizes text input.
    /// </summary>
    /// <param name="input">Raw input text.</param>
    /// <returns>Sanitized text.</returns>
    string Sanitize(string input);
}
