using System.ComponentModel.DataAnnotations;

namespace PrjWebDev2311695.Models

{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if ((DateOnly)value > DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult("The date must be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}
