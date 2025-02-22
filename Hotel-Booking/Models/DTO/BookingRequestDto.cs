using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Attributes;

namespace Models.DTO
{
    public class BookingRequestDto
    {
        public BookingRequestDto()
        {
            FirstRoom = new RoomDetails();
            SecondRoom = new RoomDetails();
            ThirdRoom = new RoomDetails();
            customerRequest = new NewCustomerRequest();
        }
        public NewCustomerRequest customerRequest {  get; set; }
        [Required]
        public int HotelBranchId { get; set; }
        [Required]
        [DateRangeValidation]
        public DateTime CheckInDate { get; set; }
        [Required]
        [DateRangeValidation]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public RoomDetails FirstRoom { get; set; }
        [ValidateNever]
        public RoomDetails? SecondRoom { get; set; }
        [ValidateNever]
        public RoomDetails? ThirdRoom { get; set; }
    }
}
