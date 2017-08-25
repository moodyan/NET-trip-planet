using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TripPlanet.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TripsController(UserManager<ApplicationUser> userManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Trips.ToList());
        }

        public IActionResult MapView(int Id)
        {
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trip => trip.TripId == Id);
            
            var tripCities = _db.TripCities.Include(city => city.City).Where(tripcity => tripcity.TripId == Id).ToArray();
            foreach (var trips in tripCities)
            {
                Console.WriteLine(trips);
            }
            return View();
        }

        public IActionResult Details(int Id)
        {
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trip => trip.TripId == Id);
            var tripCities = _db.TripCities.Include(city => city.City).Where(tripcity => tripcity.TripId == Id).ToList();
            ViewBag.Cities = tripCities;
            return View(thisTrip);
        }
        [HttpPost, ActionName("Details")]
        public IActionResult AddCity(int cityId, int id)
        {
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trips => trips.TripId == id);
            var newCity = _db.Cities.FirstOrDefault(citys => citys.CityId == cityId);
            var newTripCity = new TripCity();
            newTripCity.TripId = id;
            newTripCity.CityId = cityId;
            _db.TripCities.Add(newTripCity);
            _db.SaveChanges();
            return RedirectToAction("Details");
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Trip trip)
        //{
        //    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var currentUser = await _userManager.FindByIdAsync(userId);
        //    DateTime timestamp = DateTime.Now;
            
        //    trip.user = currentUser;
        //    _db.Trips.Add(trip);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}