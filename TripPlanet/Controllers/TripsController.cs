using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Geocoding;
using Geocoding.Google;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        public async Task<IActionResult> MapView(int Id)
        {
            var thisTrip = _db.Trips
                .Include(trips => trips.TripCities)
                .FirstOrDefault(trip => trip.TripId == Id);
            var cities = _db.Cities.Where(c => c.TripId == Id).ToList();
           
            var jsonLatLong = JsonConvert.SerializeObject(cities);
            ViewBag.TripCities = cities;
            ViewBag.LatLong = jsonLatLong;

            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = EnvironmentVariables.GeocodingAPI };
            IEnumerable<Address> addresses = await geocoder.GeocodeAsync(thisTrip.StartCity);
            var lat = addresses.First().Coordinates.Latitude;
            var lng = addresses.First().Coordinates.Longitude;
            double[] startLatLong = new double[] { lat, lng};
            ViewBag.StartLatLong = startLatLong;

            return View(thisTrip);
        }

        public IActionResult Details(int Id)
        {
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trip => trip.TripId == Id);
            var tripCities = _db.TripCities.Include(city => city.City).Where(tripcity => tripcity.TripId == Id).OrderBy(tc => tc.City.ArrivalDate).ToList();
            ViewBag.Cities = tripCities;
            ViewBag.BudgetUsed = Budget(Id);
            return View(thisTrip);
        }
        
        public IActionResult Create(int id)
        {
            var thisTrip = _db.Trips.FirstOrDefault(trip => trip.TripId == id);
            return View(thisTrip);
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
            return RedirectToAction("Details", "Trips", new { id = trip.TripId});
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

        public decimal Budget(int id)
        {
            decimal totalCost = 0;
            ViewBag.TripCities = _db.Cities.Where(c => c.TripId == id).ToList();
                
            foreach(var tc in ViewBag.TripCities)
            {
                var thisCityId = tc.CityId;
                totalCost += GetActivityCost(thisCityId);
                totalCost += GetLodgingCost(thisCityId);
                totalCost += GetTransportationCost(thisCityId);

            }
            return totalCost;
        }

        public decimal GetActivityCost(int id)
        {
            decimal activityCost = 0;
            ViewBag.Activities = _db.Activities.Where(a => a.CityId == id).ToList();
            if (ViewBag.Activities.Count != 0)
            {
                foreach (var activity in ViewBag.Activities)
                {
                    activityCost += activity.Cost;
                }
            }
            return activityCost;
        }

        public decimal GetLodgingCost(int id)
        {
            decimal lodgingCost = 0;

            ViewBag.Lodgings = _db.Lodgings.Where(a => a.CityId == id).ToList();
            if (ViewBag.Lodgings.Count != 0)
            {
                foreach (var lodging in ViewBag.Lodgings)
                {
                    lodgingCost += lodging.Cost;
                }
            }

            return lodgingCost;
        }

        public decimal GetTransportationCost(int id)
        {
            decimal transportationCost = 0;

            ViewBag.Transportations = _db.Transportations.Where(a => a.CityId == id).ToList();

            if (ViewBag.Transportations.Count != 0)
            {
                foreach (var transportation in ViewBag.Transportations)
                {
                    transportationCost += transportation.Cost;
                }
            }

            return transportationCost;
        }
    }
}