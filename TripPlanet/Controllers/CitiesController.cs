using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Geocoding;
using Geocoding.Google;

namespace TripPlanet.Controllers
{
    public class CitiesController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CitiesController(UserManager<ApplicationUser> userManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Create()
        {
            //var thisTrip = _db.Trips.FirstOrDefault(trip => trip.TripId == id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(int id, City city)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = EnvironmentVariables.GeocodingAPI };
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync(city.Name);
            Console.WriteLine("Coordinates: " + addresses.First().Coordinates.Latitude + ", " + addresses.First().Coordinates.Longitude);

            _db.Cities.Add(city);
            _db.SaveChanges();
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trips => trips.TripId == id);

            var newTripCity = new TripCity();
            newTripCity.TripId = id;
            newTripCity.CityId = city.CityId;
            _db.TripCities.Add(newTripCity);
            _db.SaveChanges();
            return RedirectToAction("Details");
        }

        
    }
}
