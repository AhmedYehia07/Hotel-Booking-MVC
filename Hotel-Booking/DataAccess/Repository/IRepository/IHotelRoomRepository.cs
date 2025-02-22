using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Repository.IRepository
{
    public interface IHotelRoomRepository:IRepository<HotelRoom>
    {
        Task UpdateAsync(HotelRoom hotelRoom);
        Task<double> GetRoomPriceAsync(int RoomId, int BranchId);
    }
}
