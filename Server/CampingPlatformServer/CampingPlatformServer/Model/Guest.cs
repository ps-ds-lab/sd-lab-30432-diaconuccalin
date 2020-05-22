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

        public DateTime DateOfBirth { get; set; }

        [Phone(ErrorMessage = "Wrong phone format")]
        [Required(ErrorMessage = "Phone required")]
        public string TelephoneNumber { get; set; }

        public string ProfilePictureLocation { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }

        public void Copy(Guest guest)
        {
            this.DateOfBirth = guest.DateOfBirth;
            this.TelephoneNumber = guest.TelephoneNumber;
            this.ProfilePictureLocation = guest.ProfilePictureLocation;
            this.Description = guest.Description;
        }
    }
}
