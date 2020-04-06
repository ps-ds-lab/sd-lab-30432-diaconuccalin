using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampingPlatformServer.Model
{
    public class User : IdentityUser
    {
        public Guid CorrespondingId { get; set; }
    }
}
