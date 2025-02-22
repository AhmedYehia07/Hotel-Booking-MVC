using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Repository.IRepository
{
    public interface IBookingDetailsRepository : IRepository<BookingDetails>
    {
        Task UpdateAsync(BookingDetails bookingDetails);
        Task<bool> CheckOldBookings(int CustomerId);
    }
}
