﻿using System.ComponentModel.DataAnnotations;

namespace ProductDevelopment.Web.Models
{
    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me222?")]
        public bool RememberMe { get; set; }
    }
}