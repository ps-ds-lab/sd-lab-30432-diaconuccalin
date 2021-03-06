﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CampingPlatformServer.Model.Users
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid CorrespondingID { get; set; }
    }
}
