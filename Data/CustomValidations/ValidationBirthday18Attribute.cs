using System;
using System.ComponentModel.DataAnnotations;

namespace crud_webapp.Data
{
    internal class ValidationBirthday18Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (
                DateTime.Parse(value.ToString()) <= DateTime.Now.AddYears(-18)) ?
                ValidationResult.Success
                : new ValidationResult("Invalid birthday."
                );
        }
    }
}