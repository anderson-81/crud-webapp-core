using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_webapp.Data;
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

        [TempData]
        public string message { get; set; }
        [TempData]
        public string title { get; set; }
        [TempData]
        public string style { get; set; }

        private static byte[] _picture;

        public EditModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _dbContext.Customer.FindAsync(id);
            if (Customer != null)
            {
                _picture = Customer.Picture;
                return Page();
            }
            CreateMessage("Customer not found.", 4);
            return RedirectToPage("/Customers/Index");
        }

        public async Task<IActionResult> OnPostAsync(IFormFile picture)
        {
            try
            {
                if (!ModelState.IsValid)
                {
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
                CreateMessage("Successfully edited.");
            }
            catch (Exception)
            {
                CreateMessage("Error to editing.", 4);
                return Page();
            }

            return RedirectToPage("/Customers/Index");
        }

        private void CreateMessage(string text, int type = 1)
        {
            alert.SendMessage(text);
            title = alert.Title;
            message = alert.Message;
            style = alert.Style;
        }
    }
}
