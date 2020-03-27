using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    [Table("GuestRequest")]
    public class GuestRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Guest))]
        public Guid GuestId { get; set; }

        public Guest Guest { get; set; }

        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        [Required(ErrorMessage = "Period required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Period required")]
        public DateTime EndDate { get; set; }

        public void Copy(GuestRequest guestRequest)
        {
            this.GuestId = guestRequest.GuestId;
            this.Guest = guestRequest.Guest;
            this.LocationId = guestRequest.LocationId;
            this.Location = guestRequest.Location;
            this.StartDate = guestRequest.StartDate;
            this.EndDate = guestRequest.EndDate;
        }
    }
}
