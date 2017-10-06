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

        public IActionResult Index(int Id)
        {
            var thisTrip = _db.Trips.FirstOrDefault(t => t.TripId == Id);
            ViewBag.Trip = thisTrip;

            var cities = _db.Cities
                .Where(c => c.TripId == Id)
                .OrderBy(tc => tc.ArrivalDate)
                .ToList();

            ViewBag.Cities = cities;

            var tripCities = _db.TripCities
                .Include(city => city.City)
                .Where(tripcity => tripcity.TripId == Id)
                .OrderBy(tc => tc.City.ArrivalDate)
                .ToList();

            return View(cities);
        }

        public IActionResult Create(int Id)
        {
            var thisTrip = _db.Trips.FirstOrDefault(t => t.TripId == Id);
            ViewBag.Trip = thisTrip;
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
            
            var arrivalTransportation = _db.Transportations.FirstOrDefault(transportation => transportation.ArrivalCityId == Id);
            ViewBag.ArrivalTransport = arrivalTransportation;
            var departureTransportation = _db.Transportations.FirstOrDefault(city => city.CityId == Id);
            ViewBag.DepartureTransport = departureTransportation;

            if (arrivalTransportation !=null)
            {
                var arrivalCity = _db.Cities
                    .Where(city => city.CityId == arrivalTransportation.CityId).ToList();
                ViewBag.ArrivalCity = arrivalCity;
            }

            if (departureTransportation != null)
            {
                var departCity = _db.Cities
                    .Where(city => city.CityId == departureTransportation.ArrivalCityId).ToList();
                ViewBag.DepartureCity = departCity;
            }

            ViewBag.ActivityCost = GetActivityCost(Id);
            ViewBag.LodgingCost = GetLodgingCost(Id);
            ViewBag.TransportationCost = GetTransportationCost(Id);
            
            ViewBag.TotalCost = ViewBag.ActivityCost+ ViewBag.LodgingCost+ ViewBag.TransportationCost;

            return View(thisCity);
        }

        public IActionResult Edit(int id)
        {
            var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
            return View(thisCity);
        }

        [HttpPost]
        public IActionResult Edit(City city, int id)
        {
            
            _db.Entry(city).State = EntityState.Modified;
            city.Duration = city.GetDuration();
            _db.SaveChanges();
            return RedirectToAction("Details", "Cities", new { id = id });
        }
        //Delete a City
        public IActionResult Delete(int id)
        {
            var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
            return View(thisCity);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            var thisCity = _db.Cities
                .FirstOrDefault(city => city.CityId == id);
            var thisTrip = _db.Trips.Include(trips => trips.TripCities).FirstOrDefault(trips => trips.TripId == thisCity.TripId);

            _db.Activities.RemoveRange(_db.Activities.Where(activity => activity.Cities.CityId == thisCity.CityId));
            _db.Lodgings.RemoveRange(_db.Lodgings.Where(lodging => lodging.Cities.CityId == thisCity.CityId));
            _db.Transportations.RemoveRange(_db.Transportations.Where(transportation => transportation.Cities.CityId == thisCity.CityId));
           
            _db.Cities.Remove(thisCity);
            _db.SaveChanges();
            return RedirectToAction("Details", "Trips", new { id = thisTrip.TripId });
        }

        public decimal GetActivityCost(int id)
        {
            decimal activityCost = 0;
            
            ViewBag.Activities = _db.Activities.Where(a => a.CityId == id).ToList();
            if(ViewBag.Activities.Count != 0)
            {
                foreach(var activity in ViewBag.Activities)
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
