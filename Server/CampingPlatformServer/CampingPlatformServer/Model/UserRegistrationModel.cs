using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model
{
    public class UserRegistrationModel
    {
        public Guid CorrespondingId;

        [Required(ErrorMessage = "Full name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords must match.")]
        public string ConfirmPassword { get; set; }
    }
}
