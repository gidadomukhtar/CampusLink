namespace CampusLink.Domain.Common;

/// <summary>
/// Provides guard clause helpers for enforcing invariants at domain and application boundaries.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Ensures the provided text is not null, empty, or whitespace.
    /// </summary>
    /// <param name="value">Input value to validate.</param>
    /// <param name="parameterName">Parameter name for exception context.</param>
    /// <returns>The validated string.</returns>
    /// <exception cref="ArgumentException">Thrown when value is null or whitespace.</exception>
    public static string NotNullOrWhiteSpace(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    /// <summary>
    /// Ensures the provided text does not exceed the configured length.
    /// </summary>
    /// <param name="value">Input value to validate.</param>
    /// <param name="maxLength">Maximum allowed length.</param>
    /// <param name="parameterName">Parameter name for exception context.</param>
    /// <returns>The original input string when valid.</returns>
    /// <exception cref="ArgumentException">Thrown when value exceeds max length.</exception>
    public static string MaxLength(string value, int maxLength, string parameterName)
    {
        if (value.Length > maxLength)
        {
            throw new ArgumentException($"{parameterName} exceeds {maxLength} characters.", parameterName);
        }

        return value;
    }
}
