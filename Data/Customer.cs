using crud_webapp.Data.CustomValidations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud_webapp.Data
{
    public class Customer
    {
        [NotMapped]
        public DbSet<Customer> Customers { get; set; }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is empty.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Amount of character is invalid for name. Minimum of 3 and maximum of 45.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is empty")]
        [StringLength(45, MinimumLength = 7, ErrorMessage = "Amount of character is invalid for name. Minimum of 7 and maximum of 45.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email.")]
        //[ValidationUniqueEmail(ErrorMessage = "E-mail already exists.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is empty")]
        [Range(0, 999999999999.99, ErrorMessage = "Invalid salary.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Birthday is empty.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid birthday.")]
        [ValidationBirthday18(ErrorMessage = "Only people over the age of 18 can be registered.")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is empty.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Amount of character is invalid for gender. Only one caracter.")]
        [ValidationGenderAttribute(ErrorMessage = "Invalid gender.")]
        public string Gender { get; set; }

        // [Required(ErrorMessage = "Picture is empty.")]
        public byte[] Picture { get; set; }
    }
}
