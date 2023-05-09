namespace Spoon.NuGet.Core.Validation;

/// <summary>
/// Attribute used to validate the values of properties and fields in a class.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ValidateAttribute : Attribute
{
    /// <summary>
    /// Gets the type of validation to perform.
    /// </summary>    
    public ValidateEnum ValidateEnum { get; }

    /// <summary>
    /// Gets the minimum length of the property or field value (for ValidateEnum.StringLength).
    /// </summary>    
    public int MinLength { get; }

    /// <summary>
    /// Gets the maximum length of the property or field value (for ValidateEnum.StringLength).
    /// </summary>
    public int MaxLength { get; }

    /// <summary>
    /// Gets the minimum value that the property or field can have (for ValidateEnum.GreaterThan and ValidateEnum.GreaterThanOrEqualTo).
    /// </summary>
    public int MinValue { get; }

    /// <summary>
    /// Gets the maximum value that the property or field can have (for ValidateEnum.LessThanOrEqualTo and ValidateEnum.LessThan).
    /// </summary>
    public int MaxValue { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidateAttribute"/> class.
    /// </summary>
    /// <param name="validateEnum">The type of validation to perform.</param>
    /// <exception cref="ArgumentException">Thrown if an invalid ValidateEnum value is provided.</exception>
    public ValidateAttribute(ValidateEnum validateEnum)
    {
        switch (validateEnum)
        {
            case ValidateEnum.Email:
                this.MinLength = 1;
                this.MaxLength = int.MaxValue;
                this.MinValue = int.MinValue;
                this.MaxValue = int.MaxValue;
                break;
            case ValidateEnum.StringLength:
            case ValidateEnum.GreaterThan:
            case ValidateEnum.LessThanOrEqualTo:
            case ValidateEnum.GreaterThanOrEqualTo:
            case ValidateEnum.LessThan:
                throw new ArgumentException("Invalid ValidateEnum value values for minValue and maxValue required", nameof(validateEnum));
            default:
                throw new ArgumentException("Invalid ValidateEnum value", nameof(validateEnum));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidateAttribute"/> class.
    /// </summary>
    /// <param name="validateEnum">The type of validation to perform.</param>
    /// <param name="minValue">The minimum value that the property or field can have.</param>
    /// <param name="maxValue">The maximum value that the property or field can have.</param>
    /// <exception cref="ArgumentException">Thrown if an invalid ValidateEnum value is provided.</exception>
    public ValidateAttribute(ValidateEnum validateEnum, int minValue, int maxValue)
    {
        this.ValidateEnum = validateEnum;

        switch (validateEnum)
        {
            case ValidateEnum.Email:
                this.MinLength = 1;
                this.MaxLength = int.MaxValue;
                this.MinValue = int.MinValue;
                this.MaxValue = int.MaxValue;
                break;
            case ValidateEnum.StringLength:
                this.MinLength = minValue;
                this.MaxLength = maxValue;
                this.MinValue = int.MinValue;
                this.MaxValue = int.MaxValue;
                break;
            case ValidateEnum.GreaterThan:
                this.MinLength = 1;
                this.MaxLength = int.MaxValue;
                this.MinValue = minValue;
                this.MaxValue = int.MaxValue;
                break;
            case ValidateEnum.LessThanOrEqualTo:
                this.MinLength = 1;
                this.MaxLength = int.MaxValue;
                this.MinValue = int.MinValue;
                this.MaxValue = maxValue;
                break;
            case ValidateEnum.GreaterThanOrEqualTo:
                this.MinLength = 1;
                this.MaxLength = int.MaxValue;
                this.MinValue = minValue;
                this.MaxValue = int.MaxValue;
                break;
            case ValidateEnum.LessThan:
                this.MinLength = 1;
                this.MaxLength = int.MaxValue;
                this.MinValue = int.MinValue;
                this.MaxValue = maxValue;
                break;
            default:
                throw new ArgumentException("Invalid ValidateEnum value", nameof(validateEnum));
        }
    }
}