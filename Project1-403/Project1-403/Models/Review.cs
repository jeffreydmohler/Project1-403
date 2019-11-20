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
        [Display(Name = "Review Code")]
        public int ReviewCode { get; set; }

        [Required]
        [Display(Name = "Restaurant Code")]
        public int RestCode { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Overall rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Overall Rating")]
        public float ReviewOverallRating { get; set; }

        [Required]
        [Display(Name = "Is restaruant date friendly?")]
        public bool? ReviewDateFriendly { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Cleanliness rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Restaurant Cleanliness")]
        public float ReviewCleanliness { get; set; }

        [Required]
        [Display(Name = "Review Date")]
        public string ReviewDate { get; set; }

        [StringLength(800, MinimumLength = 4, ErrorMessage = "Reviews should be between 4 to 800 characters long.")]
        [Display(Name = "Review Description")]
        public string ReviewDesc { get; set; }
    }
}