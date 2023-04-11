namespace Spoon.NuGet.Core.Validation;

/// <summary>
/// Specifies that validation should be excluded for the target property or field.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ValidationExcludedAttribute : Attribute
{
}
