using CampingPlatformServer.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    [Table("LocationDate")]
    public class LocationDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        public string Day { get; set; }

        public void Copy(LocationDate locationDate)
        {
            this.LocationId = locationDate.LocationId;
            this.Location = locationDate.Location;
            this.Day = locationDate.Day;
        }
    }
}
