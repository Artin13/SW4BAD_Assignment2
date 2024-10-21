using System.ComponentModel.DataAnnotations;

namespace SW4BADAssignment2.Validators;

public class DishPriceValidatorAttribute : ValidationAttribute
{
    public DishPriceValidatorAttribute(): base("Price must be greater than zero.") { }
    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is int price)
        {
            if (price < 0)
            {
                return new ValidationResult("Price must be greater than zero.");
            }
        }
        else
        {
            return new ValidationResult("Invalid price value.");
        }

        return ValidationResult.Success;
    }
}