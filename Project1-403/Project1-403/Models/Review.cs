using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    public class Review
    {
        [Required]
        public int ReviewCode { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Restaurant code must be 2 to 5 characters long.")]
        public string RestCode { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Overall rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        public float ReviewOverallRating { get; set; }

        [Required]
        public bool? ReviewDateFriendly { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Cleanliness rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        public float ReviewCleanliness { get; set; }

        [Required]
        public string ReviewDate { get; set; }

        [StringLength(800, MinimumLength = 4, ErrorMessage = "Reviews should be between 4 to 800 characters long.")]
        public string ReviewDesc { get; set; }
    }
}