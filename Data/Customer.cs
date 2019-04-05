using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud_webapp.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is empty."), 
            StringLength(100, 
            MinimumLength = 3, 
            ErrorMessage = "Amount of character is invalid for name. " +
            "Minimum of 3 and maximum of 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary is empty")]
        [Range(0, 999999999999.99, ErrorMessage = "Invalid salary.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Birthday is empty.")]
        [ValidationBirthday18]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Gender is empty.")]
        //[ValidationGender]
        public string Gender { get; set; }

        //[Required(ErrorMessage = "Picture is empty.")]
        public byte[] Picture { get; set; }
    }
}
