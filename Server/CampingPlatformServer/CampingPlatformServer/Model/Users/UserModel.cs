﻿using CampingPlatformServer.Helpers;
using System;

namespace CampingPlatformServer.Model.Users
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public Guid CorrespondingID { get; set; }
    }
}
