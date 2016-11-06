using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace FISWeb.Models
{
    public class CreateEmployeeModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Firstname")]
        public string first_name { get; set; }

        [Display(Name = "Position")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Position")]
        public string posID { get; set; }

        [Display(Name = "Department")]
        public string department { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Number phone")]
        public string phone { get; set; }
    }
}
