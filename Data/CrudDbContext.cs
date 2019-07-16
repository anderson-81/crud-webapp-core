using crud_webapp.Data;
using Microsoft.EntityFrameworkCore;

namespace crud_webapp
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext()
        {
        }

        public CrudDbContext(DbContextOptions<CrudDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID=;Password=;Host=;Port=5432;Database=;");
        }
    }
}