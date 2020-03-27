using Microsoft.EntityFrameworkCore;
using System;

namespace CampingPlatformServer.Model
{
    public class CampingPlatformContext : DbContext
    {
        public CampingPlatformContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(new Guest
            {
                Id = Guid.Parse("99117ce4-f509-4f25-9213-08a1eb11cbd1"),
                Username = "User1",
                Password = "Password1",
                FirstName = "User",
                LastName = "One",
                DateOfBirth = new DateTime(1975, 10, 8),
                TelephoneNumber = "+40749635568",
                Email = "user@one.com"
            });

            modelBuilder.Entity<Host>().HasData(new Host
            {
                Id = Guid.Parse("82e203d2-8dfc-408c-81fd-06ce41db478e"),
                Username = "User2",
                Password = "Password2",
                FirstName = "Another User",
                LastName = "Two",
                DateOfBirth = new DateTime(1992, 5, 1),
                TelephoneNumber = "+40749865768",
                Email = "another.user@two.com"
            },
            new Host
            {
                Id = Guid.Parse("6b4b958d-ea5c-4541-80f4-91e3779fb46a"),
                Username = "User3",
                Password = "Password3",
                FirstName = "Last User",
                LastName = "Three",
                DateOfBirth = new DateTime(1963, 12, 12),
                TelephoneNumber = "+40749896568",
                Email = "lastUser@three.com"
            });
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestRequest> GuestRequests { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationDate> LocationDates { get; set; }
        public DbSet<LocationImage> LocationImages { get; set; }
    }
}
