﻿using System.ComponentModel.DataAnnotations;

namespace CampingPlatformServer.Model.Users
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
