using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreadsBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace BreadsBakery.Controllers
{
    public class UserController : Controller
    {
        private BreadsBakeryDbContext db = new BreadsBakeryDbContext();
      
        public IActionResult Index()
        {
            var thisUser = db.Users.Include(i => i.CateringOrders).FirstOrDefault(i => i.UserName == User.Identity.Name);
        
            if (thisUser != null)
            {
                return View(thisUser);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(User user)
        {
            user.UserName = User.Identity.Name;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
