using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreadsBakery.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CateringOrder cateringOrder)
        {
            db.CateringOrders.Add(cateringOrder);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult PlaceOrder()
        {
            //ViewBag.thisOrder = db.CateringOrders.FirstOrDefault(order => order.CateringOrderId == id);

            ViewBag.CateringOrderId = new SelectList(db.CateringOrders, "CateringOrderId", "CateringOrderId");

            ViewBag.List = db.CateringProducts.ToList();

            ViewBag.CateringProductId = new SelectList(db.CateringProducts, "CateringProductId", "CateringProductId");
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            order.CateringProductId = order.CateringProductId;
            db.Orders.Add(order);
 
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
