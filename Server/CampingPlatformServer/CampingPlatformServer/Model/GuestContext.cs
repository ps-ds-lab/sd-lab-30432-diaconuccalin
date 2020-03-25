using Microsoft.EntityFrameworkCore;

namespace CampingPlatformServer.Model
{
    public class GuestContext : DbContext
    {
        public GuestContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Guest> Guests { get; set; }
    }
}
