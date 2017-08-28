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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, City city)
        {
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = EnvironmentVariables.GeocodingAPI };
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync(city.Name);
            city.Latitude = addresses.First().Coordinates.Latitude;
            city.Longitude = addresses.First().Coordinates.Longitude;

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

        public IActionResult Details(int Id)
        {
            var thisCity = _db.Cities.Include(cities => cities.TripCities).FirstOrDefault(city => city.CityId == Id);
            var activities = _db.Activities.Where(activity => activity.CityId == Id).ToList();
            ViewBag.Activities = activities;
            return View(thisCity);
        }
    }
}
