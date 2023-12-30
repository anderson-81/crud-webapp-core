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
        private readonly ApplicationDbContext _dbContext;

        private Alert alert;

        [BindProperty]
        public Customer Customer { get; private set; }

        [TempData]
        public string Avatar { get; set; }

        public DetailsModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert(this);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _dbContext.Customer.FindAsync(id);
            if (Customer != null)
            {
                return Page();
            }

            alert.ShowMessage("Customer not found.", 4);
            return RedirectToPage("Customers/Index");
        }
    }
}