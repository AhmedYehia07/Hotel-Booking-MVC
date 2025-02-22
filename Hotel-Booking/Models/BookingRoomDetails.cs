using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models
{
    public class BookingRoomDetails
    {
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        [ForeignKey("BookingDetails")]
        public int BookingDetailsId { get; set; }
        [Required]
        [Range(0,4)]
        public int NoOfAdults { get; set; }
        [Required]
        [Range(0,4)]
        public int NoOfChildren { get; set; }
        [ValidateNever]
        public RoomType RoomType { get; set; }
        [ValidateNever]
        public BookingDetails BookingDetails { get; set; }
    }
}
