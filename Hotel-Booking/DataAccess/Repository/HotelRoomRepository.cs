using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Repository
{
    public class HotelRoomRepository : Repository<HotelRoom>, IHotelRoomRepository
    {
        private readonly ApplicationDbContext dbContext;
        public HotelRoomRepository(ApplicationDbContext _dbContext) : base(_dbContext) 
        {
            dbContext = _dbContext;
        }

        public async Task<double> GetRoomPriceAsync(int RoomId, int BranchId)
        {
            var hotelRoom = await dbContext.HotelRooms.FirstOrDefaultAsync(u => u.RoomId == RoomId && u.BranchId == BranchId);
            var price = hotelRoom.PricePerNight;
            return price;
        }

        public async Task UpdateAsync(HotelRoom hotelRoom)
        {
            dbContext.HotelRooms.Update(hotelRoom);
            await dbContext.SaveChangesAsync();
        }
    }
}
