﻿using System.ComponentModel.DataAnnotations;

namespace PremierLeagueBlog.Server.Data.Models
{
    public class ApiRegisterRequest
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
