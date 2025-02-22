using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Utility;

namespace DataAccess.Repository
{
    public class BookingDetailsRepository : Repository<BookingDetails>, IBookingDetailsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public BookingDetailsRepository(ApplicationDbContext _dbContext): base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> CheckOldBookings(int CustomerId)
        {
            var oldBooking = await dbContext.Bookings.FirstOrDefaultAsync(u=>u.CustomerId == CustomerId && u.CheckOutDate <= DateTime.Now
            && u.Status == SD.Confirmed);
            if (oldBooking != null)
            {
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(BookingDetails bookingDetails)
        {
            dbContext.Bookings.Update(bookingDetails);
            await dbContext.SaveChangesAsync();
        }
    }
}
