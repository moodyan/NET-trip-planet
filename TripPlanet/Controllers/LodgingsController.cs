using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Edit(int id)
        {
            var thisLodging = _db.Lodgings.FirstOrDefault(l => l.LodgingId == id);
            return View(thisLodging);
        }

        [HttpPost]
        public IActionResult Edit(Lodging lodging, int id)
        {
            _db.Entry(lodging).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", "Lodgings", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            var thisLodging = _db.Lodgings.FirstOrDefault(l => l.LodgingId == id);
            return View(thisLodging);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLodging = _db.Lodgings
                .FirstOrDefault(l => l.LodgingId == id);

            _db.Lodgings.Remove(thisLodging);
            _db.SaveChanges();
            return RedirectToAction("Details", "Cities", new { id = thisLodging.CityId });
        }
    }
}
