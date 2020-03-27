using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    [Table("Guest")]
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username required")]
        [StringLength(60, ErrorMessage = "Username can't be longer than 60 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full name required")]
        [StringLength(60, ErrorMessage = "First name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Full name required")]
        [StringLength(60, ErrorMessage = "Last name can't be longer than 60 characters")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Phone(ErrorMessage = "Wrong phone format")]
        [Required(ErrorMessage = "Phone required")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Wrong email format")]
        [StringLength(60, ErrorMessage = "Email address can't be longer than 60 characters")]
        public string Email { get; set; }

        public string ProfilePictureLocation { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }

        public ICollection<GuestRequest> GuestRequests { get; set; }

        public void Copy(Guest guest)
        {
            this.Username = guest.Username;
            this.Password = guest.Password;
            this.FirstName = guest.FirstName;
            this.LastName = guest.LastName;
            this.DateOfBirth = guest.DateOfBirth;
            this.TelephoneNumber = guest.TelephoneNumber;
            this.Email = guest.Email;
            this.ProfilePictureLocation = guest.ProfilePictureLocation;
            this.Description = guest.Description;
            this.GuestRequests = guest.GuestRequests;
        }
    }
}
