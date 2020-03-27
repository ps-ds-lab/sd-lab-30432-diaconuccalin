using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model
{
    [Table("LocationImage")]
    public class LocationImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }

        public Location Location { get; set; }

        [Required(ErrorMessage = "Picture file required")]
        public string PictureLocation { get; set; }
        public void Copy(LocationImage locationImage)
        {
            this.LocationId = locationImage.LocationId;
            this.Location = locationImage.Location;
            this.PictureLocation = locationImage.PictureLocation;
        }
    }
}
