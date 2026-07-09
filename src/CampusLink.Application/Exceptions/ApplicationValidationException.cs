namespace CampusLink.Application.Exceptions;

/// <summary>
/// Represents an application-layer validation failure.
/// </summary>
public sealed class ApplicationValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationValidationException"/> class.
    /// </summary>
    /// <param name="message">Validation failure message.</param>
    public ApplicationValidationException(string message)
        : base(message)
    {
    }
}
