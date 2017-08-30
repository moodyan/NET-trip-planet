using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Geocoding;
using Geocoding.Google;
using Microsoft.AspNetCore.Authorization;

namespace TripPlanet.Controllers
{
    [Authorize]
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
            city.Duration = city.GetDuration();
            city.TripId = id;
            _db.Cities.Add(city);
            _db.SaveChanges();
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trips => trips.TripId == id);

            var newTripCity = new TripCity();
            newTripCity.TripId = id;
            newTripCity.CityId = city.CityId;
            _db.TripCities.Add(newTripCity);
            _db.SaveChanges();
            return RedirectToAction("Details", "Trips", new { id = id});
        }

        public IActionResult Details(int Id)
        {
            var thisCity = _db.Cities
                .Include(cities => cities.TripCities)
                .Include(transportations => transportations.Transportations)
                .FirstOrDefault(city => city.CityId == Id);
          
            
            var activities = _db.Activities.Where(activity => activity.CityId == Id).ToList();
            ViewBag.Activities = activities;
            var lodging = _db.Lodgings.Where(lodgings => lodgings.CityId == Id).ToList();
            ViewBag.Lodging = lodging;
            //transportation.ArrivalCityId == thisCity.Id && transportation.TripId == thisCity.TripId

            var arrivalTransport = _db.Transportations
                .Where(cityTransportation => cityTransportation.ArrivalCityId == thisCity.CityId)
                .Where(cityTransportation => cityTransportation.TripId == thisCity.TripId)
                .ToList();
            ViewBag.ArrivalTransport = arrivalTransport;

            var departTransport = _db.Transportations
                .Where(cityTransportation => cityTransportation.CityId == thisCity.CityId)
                .Where(cityTransportation => cityTransportation.TripId == thisCity.TripId).ToList()
                .ToList();
            ViewBag.DepartureTransport = departTransport;

            return View(thisCity);
        }
    }
}
