using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid HostId { get; set; }

        public User User;

        [Required(ErrorMessage = "Maximum number of guests required")]
        public int MaxNoGuests { get; set; }

        [Required(ErrorMessage = "Physical address required")]
        [StringLength(200, ErrorMessage = "Username can't be longer than 200 characters")]
        public string PhysicalAddress { get; set; }

        [StringLength(400, ErrorMessage = "Description can't be longer than 400 characters")]
        public string Description { get; set; }

        public string Days { get; set; }

        public ICollection<GuestRequest> GuestRequests { get; set; }

        public ICollection<LocationDate> LocationDates { get; set; }

        public ICollection<LocationImage> LocationImages { get; set; }

        public void Copy(Location location)
        {
            this.HostId = location.HostId;
            this.User = location.User;
            this.MaxNoGuests = location.MaxNoGuests;
            this.PhysicalAddress = location.PhysicalAddress;
            this.Description = location.Description;
            this.GuestRequests = location.GuestRequests;
            this.LocationDates = location.LocationDates;
            this.LocationImages = location.LocationImages;
            this.Days = location.Days;
        }
    }
}
