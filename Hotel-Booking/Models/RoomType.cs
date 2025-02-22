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
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int AdultCapacity { get; set; }
        [Required]
        public int ChildCapacity { get; set; }
        [ValidateNever]
        public List<BookingDetails> BookingDetails { get; set; } = default!;
        [ValidateNever]
        public List<BookingRoomDetails> RoomDetails { get; set; } = default!;
        [ValidateNever]
        public List<HotelBranch> HotelBranches { get; set; } = default!;
        [ValidateNever]
        public List<HotelRoom> HotelRooms { get; set;} = default!;
    }
}
