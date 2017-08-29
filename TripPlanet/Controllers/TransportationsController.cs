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
            //Id = CityId;
            var thisTrip = _db.Trips.Where(trip => trip.TripId == thisCity.TripId);
            var tripCities = _db.Cities.Where(city => city.TripId == thisCity.TripId).ToList();
           
            //get current trip id
            //get list of cities that match thisCity.TripId
            ViewBag.Cities = tripCities;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, Transportation transportation)
        {
            var thisCity = _db.Cities.Include(cityTrasport => cityTrasport.CityTransportations).FirstOrDefault(city => city.CityId == id);
            transportation.DepartureCityId = id;

            _db.Transportations.Add(transportation);
            _db.SaveChanges();

            var departureCityTransportation = new CityTransportation();
            departureCityTransportation.CityId = id;
            departureCityTransportation.TransportationId = transportation.TransportationId;
            var arrivalCityTransportation = new CityTransportation();
            arrivalCityTransportation.CityId = transportation.ArrivalCityId;
            arrivalCityTransportation.TransportationId = transportation.TransportationId;

            _db.CityTransportations.Add(departureCityTransportation);
            _db.CityTransportations.Add(arrivalCityTransportation);
            _db.SaveChanges();
            return RedirectToAction("Details", "Trips", new { id = id });
        }

        public IActionResult Details(int Id)
        {
            var thisCity = _db.Cities
                .Include(cities => cities.TripCities)
                .Include(transportations => transportations.CityTransportations)
                .FirstOrDefault(city => city.CityId == Id);
            
            var activities = _db.Activities.Where(activity => activity.CityId == Id).ToList();
            ViewBag.Activities = activities;
            var lodging = _db.Lodgings.Where(lodgings => lodgings.CityId == Id).ToList();
            ViewBag.Lodging = lodging;
            var cityTransportations = _db.CityTransportations.Include(city => city.Transportation).Where(cityTransportation => cityTransportation.CityId == Id).ToList();
            ViewBag.Transportation = cityTransportations;
            return View(thisCity);
        }
    }
}
