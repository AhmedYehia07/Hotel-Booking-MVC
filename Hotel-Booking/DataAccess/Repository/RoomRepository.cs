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
    public class RoomRepository : Repository<RoomType>, IRoomRepository
    {
        private readonly ApplicationDbContext dbContext;
        public RoomRepository(ApplicationDbContext _dbContext) : base(_dbContext) 
        {
            dbContext = _dbContext;
        }
        public async Task UpdateAsync(RoomType room)
        {
            dbContext.RoomTypes.Update(room);
            await dbContext.SaveChangesAsync();
        }
    }
}
