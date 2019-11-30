using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [Required]
        [Display(Name = "Review Code")]
        public int ReviewCode { get; set; }

        [Required]
        [Display(Name = "Restaurant")]
        public int RestCode { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Overall rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Overall Rating")]
        public decimal ReviewOverallRating { get; set; }

        [Required]
        [Display(Name = "Is restaurant date friendly?")]
        public bool? ReviewDateFriendly { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Cleanliness rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Cleanliness")]
        public decimal ReviewCleanliness { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime ReviewDate { get; set; }

        [StringLength(800, MinimumLength = 4, ErrorMessage = "Reviews should be between 4 to 800 characters long.")]
        [Display(Name = "Describe your Experience")]
        public string ReviewDesc { get; set; }
    }
}