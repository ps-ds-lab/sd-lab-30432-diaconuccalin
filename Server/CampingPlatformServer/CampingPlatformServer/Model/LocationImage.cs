using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model
{
    public class LocationImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LocationImageId { get; set; }
        public long LocationId { get; set; }
        public string PictureLocation { get; set; }
    }
}
