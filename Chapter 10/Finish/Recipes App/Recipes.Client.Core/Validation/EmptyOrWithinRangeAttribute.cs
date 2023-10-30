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


    //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //{
    //    if (value is string valueAsString)
    //    {
    //        if (!string.IsNullOrEmpty(valueAsString))
    //        {
    //            Debug.WriteLine(valueAsString);
    //            Debug.WriteLine(valueAsString.Length);

    //            if (valueAsString.Length < MinLength ||
    //                valueAsString.Length > MaxLength)
    //            {

    //                Debug.WriteLine($"The value should be between {MinLength} and {MaxLength} characters long, or empty.");
    //                var x = ErrorMessage;
    //                return new($"The value should be between {MinLength} and {MaxLength} characters long, or empty.");
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }
    //    else
    //    {
    //        throw new ArgumentException("Value should be of type string");
    //    }
    //}
}
