using System;
using System.Threading.Tasks;
using crud_webapp.Data;
using crud_webapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crud_webapp.Pages.Customers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly CrudDbContext _dbContext;

        private Alert alert;

        private PictureConvert pictureConvert;

        [BindProperty]
        public Customer Customer { get; private set; }
        [TempData]
        public string Avatar { get; set; }


        [TempData]
        public string message { get; set; }
        [TempData]
        public string title { get; set; }
        [TempData]
        public string style { get; set; }

        public DetailsModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _dbContext.Customer.FindAsync(id);
            if (Customer != null)
            {
                //if(Customer.Picture != null)
                //{
                //    pictureConvert = new PictureConvert();
                //    Avatar = await pictureConvert.ByteToBase64(Customer.Picture);
                //}
                return Page();
            }

            CreateMessage("Customer not found.", 4);
            return RedirectToPage("Customers/Index");
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Customer = await _dbContext.Customer.FindAsync(id);
            if (Customer != null)
            {
                try
                {
                    _dbContext.Customer.Remove(Customer);
                    await _dbContext.SaveChangesAsync();
                    CreateMessage("Successfully deleted.");
                }
                catch (Exception)
                {
                    CreateMessage("Error to deleting.", 4);
                }
            }
            else
            {
                CreateMessage("Customer not found.", 4);
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