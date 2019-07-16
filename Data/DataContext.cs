using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_webapp.Data;
using crud_webapp.Services;
using Microsoft.EntityFrameworkCore;

namespace crud_webapp.Data
{
    public class DataContext
    {
        private readonly CrudDbContext _dbContext;

        public DataContext(CrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void SetData()
        {
            await _dbContext.Customer.AddRangeAsync(
            );

            await _dbContext.SaveChangesAsync();
        }
    }
}
