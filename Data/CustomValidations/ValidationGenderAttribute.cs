using System;
using System.ComponentModel.DataAnnotations;

namespace crud_webapp.Data
{
    internal class ValidationGenderAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ((value.ToString() == "M") || (value.ToString() == "F")) ?
                ValidationResult.Success :
                new ValidationResult("Invalid gender."
                );
        }
    }
}