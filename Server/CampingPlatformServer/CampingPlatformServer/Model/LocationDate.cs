using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model
{
    public class LocationDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LocationDateId { get; set; }
        public long LocationId { get; set; }
        public DateTime Date { get; set; }
    }
}
