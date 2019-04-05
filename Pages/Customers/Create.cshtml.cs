using System;
using System.Collections.Generic;
using System.IO;
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
    public class CreateModel : PageModel
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

        public CreateModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert();
            Customer = new Customer
            {
                Name = "",
                Salary = 0,
                Birthday = DateTime.Now.AddYears(-18),
                Gender = "M"
            };
        }

        public async Task<IActionResult> OnPostAsync(IFormFile picture)
        {
            try
            {
                Console.WriteLine(picture);

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if(picture != null)
                {
                    pictureConvert = new PictureConvert();
                    Customer.Picture = await pictureConvert.IFormFileToByte(picture);
                }

                _dbContext.Customer.Add(Customer);
                await _dbContext.SaveChangesAsync();

                CreateMessage("Successfully created.");
            }
            catch (Exception)
            {
                CreateMessage("Error to creating.", 4);
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