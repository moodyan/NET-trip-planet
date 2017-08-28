using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;

namespace TripPlanet.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly TripPlanetDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActivitiesController(UserManager<ApplicationUser> userManager, TripPlanetDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Details(int Id)
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Activity activity, int id)
        {
            activity.Cities = _db.Cities.FirstOrDefault(city => city.CityId == id);
            
            //ViewBag.Latitude = activity.Cities.Longiude;
            _db.Activities.Add(activity);
            _db.SaveChanges();
            return RedirectToAction("Index"); ;
        }
    }
}
