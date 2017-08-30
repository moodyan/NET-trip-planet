using Microsoft.AspNetCore.Mvc;

namespace TripPlanet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
