using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        public DateTime Date { get; set; }

        public void Copy(LocationDate locationDate)
        {
            this.LocationId = locationDate.LocationId;
            this.Location = locationDate.Location;
            this.Date = locationDate.Date;
        }
    }
}
