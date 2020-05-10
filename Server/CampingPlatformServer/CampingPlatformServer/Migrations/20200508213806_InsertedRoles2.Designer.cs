﻿// <auto-generated />
using System;
using CampingPlatformServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampingPlatformServer.Migrations
{
    [DbContext(typeof(CampingPlatformContext))]
    [Migration("20200508213806_InsertedRoles2")]
    partial class InsertedRoles2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampingPlatformServer.Model.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8db91ddd-1192-441a-8960-de2dc68704df"),
                            Password = "securePassword",
                            Username = "greatAdmin"
                        });
                });

            modelBuilder.Entity("CampingPlatformServer.Model.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ProfilePictureLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guest");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99117ce4-f509-4f25-9213-08a1eb11cbd1"),
                            DateOfBirth = new DateTime(1975, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TelephoneNumber = "+40749635568"
                        });
                });

            modelBuilder.Entity("CampingPlatformServer.Model.GuestRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("LocationId");

                    b.ToTable("GuestRequest");
                });

            modelBuilder.Entity("CampingPlatformServer.Model.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfilePictureLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Host");

                    b.HasData(
                        new
                        {
                            Id = new Guid("82e203d2-8dfc-408c-81fd-06ce41db478e"),
                            DateOfBirth = new DateTime(1992, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TelephoneNumber = "+40749865768"
                        },
                        new
                        {
                            Id = new Guid("6b4b958d-ea5c-4541-80f4-91e3779fb46a"),
                            DateOfBirth = new DateTime(1963, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TelephoneNumber = "+40749896568"
                        });
                });

            modelBuilder.Entity("CampingPlatformServer.Model.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxNoGuests")
                        .HasColumnType("int");

                    b.Property<string>("PhysicalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CampingPlatformServer.Model.LocationDate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationDate");
                });

            modelBuilder.Entity("CampingPlatformServer.Model.LocationImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationImage");
                });

            modelBuilder.Entity("CampingPlatformServer.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "cbc6c9e7-4055-418f-8da7-1c73f0e356c7",
                            ConcurrencyStamp = "a07f7c64-3037-494e-8d74-d2036fef5ffc",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "49c2375e-ce87-4de4-965c-f3858f03788d",
                            ConcurrencyStamp = "8a1de8ce-cfbd-4838-bdba-fe9f4cece557",
                            Name = "Guest",
                            NormalizedName = "GUEST"
                        },
                        new
                        {
                            Id = "13fd909f-13ce-4468-87ff-b0e2b395cbb5",
                            ConcurrencyStamp = "f4212b10-7890-4bd8-b830-07aa5cef8c88",
                            Name = "Host",
                            NormalizedName = "HOST"
                        });
                });

            modelBuilder.Entity("CampingPlatformServer.Model.GuestRequest", b =>
                {
                    b.HasOne("CampingPlatformServer.Model.Guest", "Guest")
                        .WithMany("GuestRequests")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampingPlatformServer.Model.Location", "Location")
                        .WithMany("GuestRequests")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampingPlatformServer.Model.Location", b =>
                {
                    b.HasOne("CampingPlatformServer.Model.Host", null)
                        .WithMany("Locations")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampingPlatformServer.Model.LocationDate", b =>
                {
                    b.HasOne("CampingPlatformServer.Model.Location", "Location")
                        .WithMany("LocationDates")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampingPlatformServer.Model.LocationImage", b =>
                {
                    b.HasOne("CampingPlatformServer.Model.Location", "Location")
                        .WithMany("LocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
