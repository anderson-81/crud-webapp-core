using System;
using System.Collections.Generic;
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
    public class EditModel : PageModel
    {
        private readonly CrudDbContext _dbContext;

        private Alert alert;

        private PictureConvert pictureConvert;

        [BindProperty]
        public Customer Customer { get; set; }

        private static byte[] _picture;

        private static String _email;

        public EditModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert(this);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _dbContext.Customer.FindAsync(id);
            if (Customer != null)
            {
                _picture = Customer.Picture;
                _email = Customer.Email;
                return Page();
            }
            alert.ShowMessage("Customer not found.", 4);
            return RedirectToPage("/Customers/Index");
        }

        public async Task<IActionResult> OnPostAsync(IFormFile picture)
        {
            try
            {
                if (_email != ModelState["Customer.Email"].RawValue.ToString())
                {
                    ValidationUniqueEmail vue = new ValidationUniqueEmail();
                    if(!vue.CheckEmail(ModelState["Customer.Email"].RawValue.ToString()))
                    {
                        ModelState.AddModelError("email", "E-mail already exists.");
                    }
                }

                if (!ModelState.IsValid)
                {
                    ViewData["picture"] = _picture;
                    return Page();
                }

                if (picture != null)
                {
                    pictureConvert = new PictureConvert();
                    Customer.Picture = await pictureConvert.IFormFileToByte(picture);
                }
                else
                {
                    Customer.Picture = _picture;
                }

                _dbContext.Customer.Add(Customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                alert.ShowMessage("Successfully edited.");
            }
            catch (Exception)
            {
                alert.ShowMessage("Error to editing.", 4);
                return Page();
            }

            return RedirectToPage("/Customers/Index");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Customer = await _dbContext.Customer.FindAsync(id);
            if (Customer != null)
            {
                try
                {
                    _dbContext.Customer.Remove(Customer);
                    await _dbContext.SaveChangesAsync();
                    alert.ShowMessage("Successfully deleted.");
                }
                catch (Exception)
                {
                    alert.ShowMessage("Error to deleting.", 4);
                }
            }
            else
            {
                alert.ShowMessage("Customer not found.", 4);
            }
            return RedirectToPage("/Customers/Index");
        }
    }
}
