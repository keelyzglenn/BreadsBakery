using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreadsBakery.Models;


namespace BreadsBakery.Controllers
{
    public class CateringOrderController : Controller
    {
        private BreadsBakeryDbContext db = new BreadsBakeryDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            //ViewBag.PostId = new SelectList(_db.Posts, "Id", "Description");
            //ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CateringOrder cateringOrder)
        {
            db.CateringOrders.Add(cateringOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
