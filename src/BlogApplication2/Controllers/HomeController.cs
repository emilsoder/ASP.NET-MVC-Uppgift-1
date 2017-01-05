using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Contact()
        {
            ViewData["Message"] = "Kontakta oss";

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
