using System.ComponentModel.DataAnnotations;

namespace Domain.Validations
{
    public class CapitalizeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Object cannot be null");
            }

            var firstLetter = value.ToString()[0].ToString();
            if(firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("The first letter of the field 'Product Name' must be uppercase");
            }

            return ValidationResult.Success;
        }
    }
}
