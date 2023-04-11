namespace Spoon.NuGet.Core.Validation;

/// <summary>
/// Specifies the type of validation to perform on a property or field.
/// </summary>
public enum ValidateEnum
{
    /// <summary>
    /// Validates that a string property or field contains a valid email address.
    /// </summary>
    Email,

    /// <summary>
    /// Validates that a string property or field is of a certain length.
    /// </summary>
    StringLength,

    /// <summary>
    /// Validates that a numeric property or field is greater than a specified value.
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Validates that a numeric property or field is less than or equal to a specified value.
    /// </summary>
    LessThanOrEqualTo,

    /// <summary>
    /// Validates that a numeric property or field is greater than or equal to a specified value.
    /// </summary>
    GreaterThanOrEqualTo,

    /// <summary>
    /// Validates that a numeric property or field is less than a specified value.
    /// </summary>
    LessThan,
}