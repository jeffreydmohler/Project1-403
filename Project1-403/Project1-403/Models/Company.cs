using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    public class Company
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Company name should be 1 to 50 characters long.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Address should be 1 to 30 characters long.")]
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "City should be 1 to 30 characters long.")]
        [Display(Name = "Company City")]
        public string CompanyCity { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "State should be 1 to 15 characters long.")]
        [Display(Name = "Company State")]
        public string CompanyState { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Zip code should be 3 to 12 characters long.")]
        [Display(Name = "Company Zip Code")]
        public string CompanyZipCode { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Email should be 5 to 30 characters long.")]
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }

        [Required]
        [Phone]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Phone number should be 7 to 12 characters long.")]
        [Display(Name = "Company Phone Number")]
        public string CompanyPhone { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Owner's first name should be between 1 and 20 characters long.")]
        [Display(Name = "Company Owner's First Name")]
        public string OwnerFirstName { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Owner's last name should be between 1 and 20 characters long.")]
        [Display(Name = "Company Owner's Last Name")]
        public string OwnerLastName { get; set; }

        [StringLength(1000, MinimumLength = 4, ErrorMessage = "Company description should be between 4 and 1000 characters long.")]
        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }
    }
}