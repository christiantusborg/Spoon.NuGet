namespace Spoon.NuGet.Core.Validation;

using System.Reflection;
using FluentValidation;

/// <summary>
/// A base class for defining validation rules for a given data model.
/// </summary>
/// <typeparam name="T">The type of the data model.</typeparam>
public class BaseValidator<T> : AbstractValidator<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseValidator{T}"/> class.
    /// </summary>    
    public BaseValidator()
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var excludedAttribute = property.GetCustomAttribute<ValidationExcludedAttribute>();
            if (excludedAttribute != null)
                continue;

            var validateAttribute = property.GetCustomAttribute<ValidateAttribute>();
            var propertyName = property.Name;
            switch (Type.GetTypeCode(property.PropertyType))
            {
                case TypeCode.Object when property.PropertyType == typeof(Guid):
                    this.RuleFor(x => property.GetValue(x))
                        .NotEqual(Guid.Empty)
                        .WithMessage($"{typeof(T).Name}_{propertyName}_InvalidGuid");
                    break;
                case TypeCode.String:
                    this.RuleFor(x => property.GetValue(x) as string)
                        .NotNull()
                        .WithMessage($"{typeof(T).Name}_{propertyName}_IsNull")
                        .NotEmpty()
                        .WithMessage($"{typeof(T).Name}_{propertyName}_IsEmpty");

                    if (validateAttribute is { ValidateEnum: ValidateEnum.Email })
                    {
                        this.RuleFor(x => property.GetValue(x) as string)
                            .EmailAddress()
                            .WithMessage($"{typeof(T).Name}_{propertyName}_InvalidEmailFormat");
                    }

                    if (validateAttribute is { ValidateEnum: ValidateEnum.StringLength })
                    {
                        var minLength = validateAttribute.MinLength;
                        var maxLength = validateAttribute.MaxLength;
                        this.RuleFor(x => property.GetValue(x) as string)
                            .Length(minLength, maxLength)
                            .WithMessage($"{typeof(T).Name}_{propertyName}_InvalidStringLength_MustBeBetween_{minLength}_And_{maxLength}");
                    }
                    break;
                
                case TypeCode.Int32:

                    if (validateAttribute is { ValidateEnum: ValidateEnum.GreaterThan })
                    {
                        this.RuleFor(x => property.GetValue(x) as int?)
                            .GreaterThan(validateAttribute.MinValue)
                            .WithMessage($"{typeof(T).Name}_{propertyName}_MustBeGreaterThan_{validateAttribute.MinValue}");
                    }

                    if (validateAttribute is { ValidateEnum: ValidateEnum.LessThan })
                    {
                        this.RuleFor(x => property.GetValue(x) as int?)
                            .LessThan(validateAttribute.MaxValue)
                            .WithMessage($"{typeof(T).Name}_{propertyName}_MustBeLessThan_{validateAttribute.MaxValue}");
                    }
                    
                    if (validateAttribute is { ValidateEnum: ValidateEnum.GreaterThanOrEqualTo })
                    {
                        this.RuleFor(x => property.GetValue(x) as int?)
                            .GreaterThanOrEqualTo(validateAttribute.MinValue)
                            .WithMessage($"{typeof(T).Name}_{propertyName}_MustBeGreaterThanOrEqualTo_{validateAttribute.MinValue}");
                    }

                    if (validateAttribute is { ValidateEnum: ValidateEnum.LessThanOrEqualTo })
                    {
                        this.RuleFor(x => property.GetValue(x) as int?)
                            .LessThanOrEqualTo(validateAttribute.MaxValue)
                            .WithMessage($"{typeof(T).Name}_{propertyName}_MustBeLessThanOrEqualTo_{validateAttribute.MaxValue}");
                    }
                    break;                
            }
        }

    }
}