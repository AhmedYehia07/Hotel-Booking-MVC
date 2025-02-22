using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models
{
    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("HotelBranch")]
        public int BranchId { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        public double? TotalPrice { get; set; }
        [Required]
        [AllowedValues("pending","confirmed","cancelled")]
        public string Status { get; set; } = "pending";
        [ValidateNever]
        public Customer Customer { get; set; }
        [ValidateNever]
        public HotelBranch HotelBranch { get; set; }
        public List<RoomType> RoomTypes { get; set; } = default!;
        public List<BookingRoomDetails> RoomDetails { get; set; } = default!;
    }
}
