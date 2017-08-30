﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripPlanet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            var thisTrip = _db.Trips.FirstOrDefault(trip => trip.TripId == id);
            _db.Trips.Remove(thisTrip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}