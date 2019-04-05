using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_webapp.Data;
using crud_webapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// .ToListAsync()
using Microsoft.EntityFrameworkCore;

namespace crud_webapp.Pages.Customers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CrudDbContext _dbContext;

        private Alert alert;

        [BindProperty]
        public IList<Customer> Customers { get; private set; }

        [TempData]
        public string message { get; set; }
        [TempData]
        public string title { get; set; }
        [TempData]
        public string style { get; set; }

        public IndexModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Customers = await _dbContext.Customer.ToListAsync();
            }
            catch (Exception)
            {
                CreateMessage("Error to listing.", 4);
            }
            return Page();
        }

        private void CreateMessage(string text, int type = 1)
        {
            alert.SendMessage(text, type);
            title = alert.Title;
            message = alert.Message;
            style = alert.Style;
        }
    }
}