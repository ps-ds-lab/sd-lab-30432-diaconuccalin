using CampingPlatformServer.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CampingPlatformServer.Model
{
    public class CampingPlatformContext : IdentityDbContext<User>
    {
        public CampingPlatformContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestRequest> GuestRequests { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationDate> LocationDates { get; set; }
        public DbSet<LocationImage> LocationImages { get; set; }
    }
}
