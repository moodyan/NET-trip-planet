using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TripPlanet.Models;

namespace TripPlanet.Migrations
{
    [DbContext(typeof(TripPlanetDbContext))]
    [Migration("20170816221920_OneCityToManyActivitiesLodgings")]
    partial class OneCityToManyActivitiesLodgings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TripPlanet.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("CityId");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<decimal>("TimeSpent");

                    b.Property<string>("Type");

                    b.HasKey("ActivityId");

                    b.HasIndex("CityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TripPlanet.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TripPlanet.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("Name");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TripPlanet.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<byte>("Image");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("TripPlanet.Models.Lodging", b =>
                {
                    b.Property<int>("LodgingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<bool>("Booked");

                    b.Property<int>("CityId");

                    b.Property<string>("Confirmation");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("Name");

                    b.HasKey("LodgingId");

                    b.HasIndex("CityId");

                    b.ToTable("Lodgings");
                });

            modelBuilder.Entity("TripPlanet.Models.Planner", b =>
                {
                    b.Property<int>("PlannerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("FirstName");

                    b.Property<string>("Hometown");

                    b.Property<byte>("Image");

                    b.Property<string>("LastName");

                    b.Property<string>("UserId");

                    b.HasKey("PlannerId");

                    b.HasIndex("UserId");

                    b.ToTable("Planners");
                });

            modelBuilder.Entity("TripPlanet.Models.Transportation", b =>
                {
                    b.Property<int>("TransportationId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Booked");

                    b.Property<string>("Confirmation");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("Mode");

                    b.HasKey("TransportationId");

                    b.ToTable("Transportations");
                });

            modelBuilder.Entity("TripPlanet.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDate");

                    b.Property<decimal>("Budget");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Members");

                    b.Property<string>("Name");

                    b.Property<int>("PlannerId");

                    b.Property<bool>("Public");

                    b.Property<string>("StartCity");

                    b.Property<int>("TripLength");

                    b.HasKey("TripId");

                    b.HasIndex("PlannerId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TripPlanet.Models.TripCity", b =>
                {
                    b.Property<int>("TripId");

                    b.Property<int>("CityId");

                    b.HasKey("TripId", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("TripCities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TripPlanet.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TripPlanet.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripPlanet.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripPlanet.Models.Activity", b =>
                {
                    b.HasOne("TripPlanet.Models.City", "Cities")
                        .WithMany("Activities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripPlanet.Models.Lodging", b =>
                {
                    b.HasOne("TripPlanet.Models.City", "Cities")
                        .WithMany("Lodgings")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripPlanet.Models.Planner", b =>
                {
                    b.HasOne("TripPlanet.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TripPlanet.Models.Trip", b =>
                {
                    b.HasOne("TripPlanet.Models.Planner", "Planner")
                        .WithMany("Trips")
                        .HasForeignKey("PlannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripPlanet.Models.TripCity", b =>
                {
                    b.HasOne("TripPlanet.Models.City", "City")
                        .WithMany("TripCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripPlanet.Models.Trip", "Trip")
                        .WithMany("TripCities")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
