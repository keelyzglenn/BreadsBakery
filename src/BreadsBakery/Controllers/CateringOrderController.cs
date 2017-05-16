using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreadsBakery.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BreadsBakery.Controllers
{
    public class CateringOrderController : Controller
    {
        private BreadsBakeryDbContext db = new BreadsBakeryDbContext();
        public IActionResult Index()
        {
            return View(db.CateringOrders.ToList());
        }

        public IActionResult CateringMenu()
        {
            return View(db.CateringProducts.ToList());
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
            return RedirectToAction("Index");
        }

        public IActionResult PlaceOrder(int id)
        {
            var thisProduct = db.CateringOrders.FirstOrDefault(products => products.CateringOrderId == id);
            return View(thisProduct);
        }


        //public IActionResult PlaceOrder(int id)
        //{
            //ViewBag.thisOrder = db.CateringOrders.FirstOrDefault(order => order.CateringOrderId == id);
            //ViewBag.List = db.CateringProducts.ToList();
            //ViewBag.CateringOrderId = new SelectList(db.CateringOrders, "CateringOrderId", "CateringOrderId");

            //var thisCateringOrder = db.CateringOrders.FirstOrDefault(order => order.CateringOrderId == id);

            //ViewBag.CateringProductId = new SelectList(db.CateringProducts, "CateringProductId", "CateringProductId");
        //    return View(thisCateringOrder);

        //}

        //[HttpPost]
        //public IActionResult PlaceOrder(Order order)
        //{

        //    db.Orders.Add(order);

        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}


    }
}
