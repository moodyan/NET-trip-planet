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
            var thisTrip = _db.Trips.Where(trip => trip.TripId == thisCity.TripId);
            var tripCities = _db.Cities.Where(city => city.TripId == thisCity.TripId).ToList();
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

            //var departureCityTransportation = new CityTransportation();
            //departureCityTransportation.CityId = id;
            //departureCityTransportation.TransportationId = transportation.TransportationId;
            //var arrivalCityTransportation = new CityTransportation();
            //arrivalCityTransportation.CityId = transportation.ArrivalCityId;
            //arrivalCityTransportation.TransportationId = transportation.TransportationId;

            //_db.CityTransportations.Add(departureCityTransportation);
            //_db.CityTransportations.Add(arrivalCityTransportation);
            //_db.SaveChanges();
            return RedirectToAction("Details", "Cities", new { id = id });
        }

        public IActionResult Details(int Id)
        {
            
            
            return View();
        }
    }
}
