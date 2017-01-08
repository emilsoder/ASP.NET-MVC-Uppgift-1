using Microsoft.AspNetCore.Mvc;

namespace BlogApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Om bloggen foodbyemil";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult IllegalOperation()
        {
            return View();
        }
    }
}