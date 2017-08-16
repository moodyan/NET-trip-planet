using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TripPlanet.Models
{
    public class TripPlanetDbContext : IdentityDbContext<ApplicationUser>
    {
        public TripPlanetDbContext() { }
        public DbSet<Planner> Planners { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<TripCity> TripCities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TripPlanet;integrated security=True");
        }
        public TripPlanetDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TripCity>()
                .HasKey(x => new { x.TripId, x.CityId });

            builder.Entity<TripCity>()
                .HasOne(x => x.Trip)
                .WithMany(y => y.TripCities)
                .HasForeignKey(y => y.TripId);

            builder.Entity<TripCity>()
                .HasOne(x => x.City)
                .WithMany(y => y.TripCities)
                .HasForeignKey(y => y.CityId);
            base.OnModelCreating(builder);
        }
    }
}
