using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CustomerRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task UpdateAsync(Customer customer)
        {
            dbContext.Customers.Update(customer);
            await dbContext.SaveChangesAsync();
        }
    }
}
