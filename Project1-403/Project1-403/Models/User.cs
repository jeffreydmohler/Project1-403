using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1_403.Models
{
    [Table("Users")]
    public class Users
    { 
        [Key]
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Required (ErrorMessage = "Please enter a First Name")]
        [Display(Name = "First Name")]
        public string UserFName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [Display(Name = "Last Name")]
        public string UserLName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter password again")]
        [DataType(DataType.Password)]
        [Display(Name = "Please Re-enter Password")]
        [Compare("UserPassword", ErrorMessage = "Passwords must match. Try again")]
        public string ComparePassword { get; set; }
    }
}