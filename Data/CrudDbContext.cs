using crud_webapp.Data;
using Microsoft.EntityFrameworkCore;

namespace crud_webapp
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}