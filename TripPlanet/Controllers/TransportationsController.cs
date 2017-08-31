using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TripPlanet.Controllers
{
    [Authorize]
    public class TransportationsController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransportationsController(UserManager<ApplicationUser> userManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Create(int Id)
        {
            var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == Id);
            ViewBag.DepartureCity = thisCity.Name;
            var thisTrip = _db.Trips.Where(trip => trip.TripId == thisCity.TripId);
            var tripCities = _db.Cities.Where(cities => cities.TripId == thisCity.TripId).Where(city => city.CityId != Id).ToList();
            ViewBag.Cities = new SelectList(tripCities, "CityId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, Transportation transportation)
        {
            var thisDepartureCity = _db.Cities
                .Include(cities => cities.TripCities)
                .Include(transportations => transportations.Transportations)
                .FirstOrDefault(city => city.CityId == id);
            

            transportation.CityId = id;
            transportation.TripId = thisDepartureCity.TripId;

            _db.Transportations.Add(transportation);
            _db.SaveChanges();

            return RedirectToAction("Details", "Cities", new { id = id });
        }

        public IActionResult Details(int Id)
        {
            var thisTransportation = _db.Transportations
                .FirstOrDefault(t => t.TransportationId == Id);
            
            var arrivalCity = _db.Cities
                    .Where(city => city.CityId == thisTransportation.ArrivalCityId).ToList();
            ViewBag.ArrivalCity = arrivalCity;
            var departCity = _db.Cities
                    .Where(city => city.CityId == thisTransportation.CityId).ToList();
            ViewBag.DepartureCity = departCity;

            return View(thisTransportation);
        }
        public IActionResult Edit(int id)
        {
            var thisTransportation = _db.Transportations
                .FirstOrDefault(a => a.TransportationId == id);
            var arrivalCity = _db.Cities
                .Where(city => city.CityId == thisTransportation.ArrivalCityId).ToList();
            ViewBag.ArrivalCity = arrivalCity;
            var departCity = _db.Cities
                    .Where(city => city.CityId == thisTransportation.CityId).ToList();
            ViewBag.DepartureCity = departCity;
            return View(thisTransportation);
        }

        [HttpPost]
        public IActionResult Edit(Transportation transportation, int id)
        {
            _db.Entry(transportation).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", "Transportations", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            var thisTransportation = _db.Transportations.FirstOrDefault(a => a.TransportationId == id);
            return View(thisTransportation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTransportation = _db.Transportations
                .FirstOrDefault(a => a.TransportationId == id);

            _db.Transportations.Remove(thisTransportation);
            _db.SaveChanges();
            return RedirectToAction("Details", "Cities", new { id = thisTransportation.CityId });
        }
    }
}
