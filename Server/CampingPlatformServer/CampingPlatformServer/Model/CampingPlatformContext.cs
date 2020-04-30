using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CampingPlatformServer.Model
{
    public class CampingPlatformContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public CampingPlatformContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = Guid.Parse("8db91ddd-1192-441a-8960-de2dc68704df"),
                Username = "greatAdmin",
                Password = "securePassword"
            });

            modelBuilder.Entity<Guest>().HasData(new Guest
            {
                Id = Guid.Parse("99117ce4-f509-4f25-9213-08a1eb11cbd1"),
                DateOfBirth = new DateTime(1975, 10, 8),
                TelephoneNumber = "+40749635568"
            });

            modelBuilder.Entity<Host>().HasData(new Host
            {
                Id = Guid.Parse("82e203d2-8dfc-408c-81fd-06ce41db478e"),
                DateOfBirth = new DateTime(1992, 5, 1),
                TelephoneNumber = "+40749865768"
            },
            new Host
            {
                Id = Guid.Parse("6b4b958d-ea5c-4541-80f4-91e3779fb46a"),
                DateOfBirth = new DateTime(1963, 12, 12),
                TelephoneNumber = "+40749896568"
            });
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestRequest> GuestRequests { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationDate> LocationDates { get; set; }
        public DbSet<LocationImage> LocationImages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
