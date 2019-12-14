using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    public class Restaurant
    {
        [Key]
        [Required]
        [Display(Name = "Restaurant Code")]
        public int RestID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Restaurant name should be 1 to 50 characters long.")]
        [Display(Name = "Restaurant Name")]
        public string RestName { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Overall rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Overall Rating")]
        public decimal RestOverallRating { get; set; }

        [Required]
        [Display(Name = "Date friendly?")]
        public bool RestDateFriendly { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Cleanliness rating can be a minimum of 0 stars and a maximum of 5 stars.")]
        [Display(Name = "Cleanliness Rating")]
        public decimal RestCleanliness { get; set; }

        [ForeignKey("RestaurantType")]
        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Restaurant type code should be 2 to 5 characters long.")]
        [Display(Name = "Restaurant Type Code")]
        public string RestTypeCode { get; set; }
        public virtual RestaurantType RestaurantType { get; set; }

        [ForeignKey("FoodType")]
        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Restaurant tood type code should be 2 to 5 characters long.")]
        [Display(Name = "Food Type Code")]
        public string RestFoodTypeCode { get; set; }
        public virtual FoodType FoodType { get; set; }

        [Range(.5, 200, ErrorMessage = "Average price for one meal should be between $.50 and $200.00.")]
        [Display(Name = "Average Meal Price")]
        public decimal RestAvgMealPrice { get; set; }

        [Required]
        [Phone]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Phone number should be 7 to 12 characters long.")]
        [Display(Name = "Phone Number")]
        public string RestPhone { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Address should be 1 to 30 characters long.")]
        [Display(Name = "Address")]
        public string RestAddress { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "City should be 1 to 30 characters long.")]
        [Display(Name = "City")]
        public string RestCity { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "State should be 1 to 15 characters long.")]
        [Display(Name = "State")]
        public string RestState { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Zip code should be 3 to 12 characters long.")]
        [Display(Name = "Zip Code")]
        public string RestZipCode { get; set; }
    }
}