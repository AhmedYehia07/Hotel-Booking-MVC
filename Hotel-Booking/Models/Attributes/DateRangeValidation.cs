using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;

namespace Models.Attributes
{
    public class DateRangeValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var booking = (BookingRequestDto)validationContext.ObjectInstance;

            if (booking.CheckInDate < DateTime.Today)
            {
                return new ValidationResult("Check-in date must be today or later.");
            }

            if (booking.CheckInDate >= booking.CheckOutDate)
            {
                return new ValidationResult("Check-in date must be before the check-out date.");
            }
            return ValidationResult.Success;
        }
    }
}
