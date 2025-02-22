using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models.DTO
{
    public class RoomDetails
    {
        public string RoomType { get; set; }
        [ValidateNever]
        public int NoOfAdults {  get; set; } = 0;
        [ValidateNever]
        public int NoOfChildren { get; set; } = 0;
    }
}
