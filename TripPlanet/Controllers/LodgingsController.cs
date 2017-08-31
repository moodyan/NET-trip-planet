using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TripPlanet.Controllers
{
    [Authorize]
    public class LodgingsController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public LodgingsController(UserManager<ApplicationUser> userManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        //Need to build out details view and route
        public IActionResult Details(int id)
        {
            var thisLodging = _db.Lodgings.FirstOrDefault(l => l.LodgingId == id);
            return View(thisLodging);
        }

        public IActionResult Create(int id)
        {
            var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
            ViewBag.City = thisCity;
            ViewBag.Longitude = thisCity.Longitude;
            ViewBag.Latitude = thisCity.Latitude;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lodging lodging, int id)
        {
            lodging.Cities = _db.Cities.FirstOrDefault(city => city.CityId == id);
            //IGeocoder geocoder = new GoogleGeocoder() { ApiKey = EnvironmentVariables.GeocodingAPI };
            //IEnumerable<Address> addresses = await geocoder.GeocodeAsync(lodging.Address);
            //lodging.Latitude = addresses.First().Coordinates.Latitude;
            //lodging.Longitude = addresses.First().Coordinates.Longitude;
            _db.Lodgings.Add(lodging);
            _db.SaveChanges();
            return RedirectToAction("Details", "Cities", new { id = id }); ;
        }
    }
}
