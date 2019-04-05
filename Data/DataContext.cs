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
                new Customer { Name = "Mara", Birthday = DateTime.Now.AddYears(-18), Gender = "F", Salary = 7000 },
                new Customer { Name = "Julia", Birthday = DateTime.Now.AddYears(-20), Gender = "F", Salary = 1200 },
                new Customer { Name = "Anderson", Birthday = DateTime.Now.AddYears(-22), Gender = "M", Salary = 5500 },
                new Customer { Name = "Paula", Birthday = DateTime.Now.AddYears(-23), Gender = "F", Salary = 4400 },
                new Customer { Name = "José", Birthday = DateTime.Now.AddYears(-34), Gender = "F", Salary = 1000 },
                new Customer { Name = "Laura", Birthday = DateTime.Now.AddYears(-24), Gender = "F", Salary = 1800 },
                new Customer { Name = "Adriana", Birthday = DateTime.Now.AddYears(-37), Gender = "F", Salary = 2000 }
            );

            await _dbContext.SaveChangesAsync();
        }
    }
}
