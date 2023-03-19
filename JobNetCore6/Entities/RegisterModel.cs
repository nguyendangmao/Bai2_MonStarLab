﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobNetCore6.Entities
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]   
        public string? Password { get; set; }
    }
}
