using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampingPlatformServer.Model
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LocationId { get; set; }
        public long HostId { get; set; }
        public string PhysicalAddress { get; set; }
        public string Description { get; set; }
    }
}
