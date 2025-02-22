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
    public class BookingRoomDetailsRepository:Repository<BookingRoomDetails>,IBookingRoomDetailsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public BookingRoomDetailsRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task UpdateAsync(BookingRoomDetails room)
        {
            dbContext.BookingRoomDetails.Update(room);
            await dbContext.SaveChangesAsync();
        }
    }
}
