namespace CampusLink.Domain.Exceptions;

/// <summary>
/// Represents a domain rule violation.
/// </summary>
public sealed class DomainRuleViolationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainRuleViolationException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public DomainRuleViolationException(string message)
        : base(message)
    {
    }
}
