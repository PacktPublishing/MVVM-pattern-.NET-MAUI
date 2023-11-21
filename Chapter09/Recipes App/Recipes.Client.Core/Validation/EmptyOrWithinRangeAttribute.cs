using System.ComponentModel.DataAnnotations;

namespace Recipes.Client.Core.Validation;

public class EmptyOrWithinRangeAttribute : ValidationAttribute
{
    public int MinLength { get; set; }
    public int MaxLength { get; set; }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string valueAsString && (
            string.IsNullOrEmpty(valueAsString) ||
            (valueAsString.Length >= MinLength 
            && valueAsString.Length <= MaxLength)))
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult($"The value should be between {MinLength} and {MaxLength} characters long, or empty.");

        }
    }
}
