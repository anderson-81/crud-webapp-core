using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using crud_webapp.Data;
using crud_webapp.Data.CustomValidations;
using crud_webapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crud_webapp.Pages.Customers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CrudDbContext _dbContext;

        private Alert alert;

        private PictureConvert pictureConvert;

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            Customer = new Customer
            {
                Name = "",
                Email = "",
                Salary = 0,
                Birthday = DateTime.Now.AddYears(-18),
                Gender = "M"
            };

            alert = new Alert(this);
        }

        public async Task<IActionResult> OnPostAsync(IFormFile picture)
        {
            try
            {
                ValidationUniqueEmail vue = new ValidationUniqueEmail();
                if (!vue.CheckEmail(ModelState["Customer.Email"].RawValue.ToString()))
                {
                    ModelState.AddModelError("email", "E-mail already exists.");
                }

                if (picture == null)
                {
                    ModelState.AddModelError("picture", "Picture is empty.");
                }

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                pictureConvert = new PictureConvert();
                Customer.Picture = await pictureConvert.IFormFileToByte(picture);
                
                _dbContext.Customer.Add(Customer);
                await _dbContext.SaveChangesAsync();

                alert.ShowMessage("Successfully created.");
            }
            catch (Exception)
            {
                alert.ShowMessage("Error to creating.", 4);
                return Page();
            }
            return RedirectToPage("/Customers/Index");
        }
    }
}