
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class BookingDetailsDto
    {
        public int DetailsId { get; set; }
        public string Name { get; set; }
        public int NationalId { get; set; }
        public int NoOfRooms { get; set; }
        public string PhoneNumber { get; set; }
        public string HotelBranch { get; set; }
        public string status { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ReservationDate { get; set; }
        public double? TotalPrice { get; set; }
    }
}
