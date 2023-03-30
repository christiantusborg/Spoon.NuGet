namespace Spoon.NuGet.Core.Domain;

/// <summary>
/// The operation.
/// </summary>
public enum Operation
{
    /// <summary>
    /// The equals.
    /// </summary>
    Equals,

    /// <summary>
    /// The greater than.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// The less than.
    /// </summary>
    LessThan,

    /// <summary>
    /// The greater than or equal.
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// The less than or equal.
    /// </summary>
    LessThanOrEqual,

    /// <summary>
    /// The contains.
    /// </summary>
    Contains,

    /// <summary>
    /// The starts with.
    /// </summary>
    StartsWith,

    /// <summary>
    /// The ends with.
    /// </summary>
    EndsWith,
}