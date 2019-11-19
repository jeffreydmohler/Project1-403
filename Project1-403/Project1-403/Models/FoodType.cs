using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    public class FoodType
    {
        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Restaurant food type code should be 2 to 5 characters long.")]
        public string RestFoodTypeCode { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Restaurant food type description should be 2 to 15 characters long.")]
        public string FoodTypeDesc { get; set; }
    }
}