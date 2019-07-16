using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crud_webapp.Data.CustomValidations
{
    public class ValidationUniqueEmail
    {
        public bool CheckEmail(String email)
        {
            CrudDbContext db = new CrudDbContext();
            return (db.Customer.Where(e => e.Email == email.ToString()).Count() == 0);
        }
    }
}
