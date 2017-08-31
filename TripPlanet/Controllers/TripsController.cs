using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userId);
                var userTrips = _db.Trips.Where(trips => trips.Planner.UserId == currentUser.Id).ToList();
                ViewBag.UserTrips = userTrips;
                return View(userTrips);
            } else
            {
                return View();
            }
        }

        public IActionResult PublicTrips()
        {
            var allPublicTrips = _db.Trips.Where(trips => trips.Public).ToList();
            ViewBag.PublicTrips = allPublicTrips;
            return View(allPublicTrips);
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
        
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Trip trip)
        {
            trip.Planner = _db.Planners.FirstOrDefault(planner => planner.UserName == User.Identity.Name);
            
            _db.Trips.Add(trip);
            _db.SaveChanges();
            return RedirectToAction("Index"); ;
        }

        public IActionResult Edit(int id)
        {
            var thisTrip = _db.Trips.FirstOrDefault(trip => trip.TripId == id);
            return View(thisTrip);
        }

        [HttpPost]
        public IActionResult Edit(Trip trip)
        {
            trip.Planner = _db.Planners.FirstOrDefault(planner => planner.UserName == User.Identity.Name);
            _db.Entry(trip).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete a Trip
        public IActionResult Delete(int id)
        {
            var thisTrip = _db.Trips.FirstOrDefault(trip => trip.TripId == id);
            return View(thisTrip);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTrip = _db.Trips
                .FirstOrDefault(trip => trip.TripId == id);
            
            _db.Activities.RemoveRange(_db.Activities.Where(activity => activity.Cities.TripId == thisTrip.TripId));
            _db.Lodgings.RemoveRange(_db.Lodgings.Where(lodging => lodging.Cities.TripId == thisTrip.TripId));
            _db.Transportations.RemoveRange(_db.Transportations.Where(transportation => transportation.Cities.TripId == thisTrip.TripId));
            _db.Cities.RemoveRange(_db.Cities.Where(city => city.TripId == thisTrip.TripId));
            _db.Trips.Remove(thisTrip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}