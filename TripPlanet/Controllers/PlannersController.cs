using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;

namespace TripPlanet.Controllers
{
    public class PlannersController : Controller
    {
        private TripPlanetDbContext db = new TripPlanetDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(string id)
        {
            Planner planner = db.Planners.FirstOrDefault(r => r.UserId.Equals(id));
            return View(planner);
        }
        [HttpPost]
        public IActionResult Create(string firstName, string lastName, DateTime birthdate, byte image, string hometown, string userId)
        {

            Planner planner = new Planner(firstName, lastName, birthdate, image, hometown);
            planner.UserId = userId;
            db.Planners.Add(planner);
            db.SaveChanges();

            return RedirectToAction("Index", "Trips");
        }
    }
}
