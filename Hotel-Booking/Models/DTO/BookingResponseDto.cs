using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class BookingResponseDto
    {
        public int bookingId {  get; set; }
        public double? TotalPrice { get; set; }
        public double Discount { get; set; } = 0;
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
    }
}
