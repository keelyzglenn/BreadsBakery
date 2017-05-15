using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreadsBakery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BreadsBakery.Controllers
{
    public class HomeController : Controller
    {
        private BreadsBakeryDbContext db = new BreadsBakeryDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Pastries()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult BakingClasses()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}
