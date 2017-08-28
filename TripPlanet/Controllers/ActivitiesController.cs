using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TripPlanet.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Details(int Id)
        {
            return View();
        }
    }
}
