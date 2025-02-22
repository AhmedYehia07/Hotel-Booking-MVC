using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelRoom
    {
        [ForeignKey("HotelBranch")]
        public int BranchId { get; set; }
        [ForeignKey("RoomType")]
        public int RoomId { get; set; }
        [Range(100,500)]
        public double PricePerNight { get; set; }
        public int NoOfRooms { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public RoomType RoomType { get; set; }
    }
}
