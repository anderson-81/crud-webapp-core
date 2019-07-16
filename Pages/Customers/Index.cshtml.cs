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

        public IndexModel(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
            alert = new Alert(this);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Customers = await _dbContext.Customer.ToListAsync();
            }
            catch (Exception)
            {
                alert.ShowMessage("Error to listing.", 4);
            }
            return Page();
        }
    }
}