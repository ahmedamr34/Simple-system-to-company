﻿using System.ComponentModel.DataAnnotations;

namespace Demo.PeresentationLayer.Models
{
    
        public class ForgetPasswordViewModel
        {
            [Required(ErrorMessage = "Email is Required")]
            [EmailAddress(ErrorMessage = "Invalid Email")]
            public string Email { get; set; }
        }
    
}
