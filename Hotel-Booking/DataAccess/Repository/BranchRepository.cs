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
    public class BranchRepository : Repository<HotelBranch>, IBranchRepository
    {
        private readonly ApplicationDbContext dbContext;
        public BranchRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task UpdateAsync(HotelBranch hotelBranch)
        {
            dbContext.HotelBranches.Update(hotelBranch);
            await dbContext.SaveChangesAsync();
        }
    }
}
