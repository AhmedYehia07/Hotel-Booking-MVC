using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class BookingListDto
    {
        public int DetailId { get; set; }
        public string CutomerName { get; set; }
        public string Branch { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
