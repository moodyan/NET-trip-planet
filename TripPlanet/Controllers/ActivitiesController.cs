using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TripPlanet.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActivitiesController(UserManager<ApplicationUser> userManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            var thisCity = _db.Cities.FirstOrDefault(city => city.CityId == id);
            ViewBag.Longitude = thisCity.Longitude;
            ViewBag.Latitude = thisCity.Latitude;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Activity activity, int id)
        {
            activity.Cities = _db.Cities.FirstOrDefault(city => city.CityId == id);
            
            _db.Activities.Add(activity);
            _db.SaveChanges();
            return RedirectToAction("Details", "Cities", new { id = id }); ;
        }
    }
}
