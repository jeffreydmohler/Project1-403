using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    public class Review
    {
        [Key]
        [Required]
        [Display(Name = "Review Code")]
        public int ReviewCode { get; set; }

        [ForeignKey("Restaurant")]
        [Required]
        [Display(Name = "Restaurant Code")]
        public int RestID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Overall rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Overall Rating")]
        public decimal ReviewOverallRating { get; set; }

        [Required(ErrorMessage ="The Date Friendly field is required")]
        [Display(Name = "Is restaruant date friendly?")]
        public bool? ReviewDateFriendly { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Cleanliness rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Restaurant Cleanliness")]
        public decimal ReviewCleanliness { get; set; }

        [Required(ErrorMessage = "Please input date with mm-dd-yyyy format")]
        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }

        [StringLength(800, MinimumLength = 4, ErrorMessage = "Reviews should be between 4 to 800 characters long.")]
        [Display(Name = "Review Description")]
        public string ReviewDesc { get; set; }
    }
}