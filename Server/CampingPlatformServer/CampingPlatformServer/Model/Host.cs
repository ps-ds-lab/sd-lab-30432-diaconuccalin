using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    [Table("Host")]
    public class Host
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

        [EmailAddress(ErrorMessage = "Wrong email format")]
        [Required(ErrorMessage = "Email required")]
        [StringLength(60, ErrorMessage = "Email address can't be longer than 60 characters")]
        public string Email { get; set; }

        public string ProfilePictureLocation { get; set; }
        
        public ICollection<Location> Locations { get; set; }

        public void Copy(Host host)
        {
            this.Username = host.Username;
            this.Password = host.Password;
            this.FirstName = host.FirstName;
            this.LastName = host.LastName;
            this.DateOfBirth = host.DateOfBirth;
            this.TelephoneNumber = host.TelephoneNumber;
            this.Email = host.Email;
            this.ProfilePictureLocation = host.ProfilePictureLocation;
            this.Locations = host.Locations;
        }
    }
}
