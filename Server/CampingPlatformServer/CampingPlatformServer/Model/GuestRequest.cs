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

        public Guid GuestId { get; set; }

        public Guid LocationId { get; set; }

        public bool Accepted { get; set; }

        public void Copy(GuestRequest guestRequest)
        {
            this.GuestId = guestRequest.GuestId;
            this.LocationId = guestRequest.LocationId;
            this.Accepted = guestRequest.Accepted;
        }
    }
}
