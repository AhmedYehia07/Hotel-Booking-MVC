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
    public class HotelBranch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string? ImageUrl { get; set; }
        [ValidateNever]
        public List<RoomType> RoomTypes { get; set; } = default!;
        [ValidateNever]
        public List<HotelRoom> HotelRooms { get; set; } = default!;
    }
}
