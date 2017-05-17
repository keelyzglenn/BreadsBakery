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
            return View(db.CateringOrders.Include(i => i.User).ToList());
        }

        public IActionResult CateringMenu()
        {
            return View(db.CateringProducts.ToList());
        }

        public IActionResult Create()
        {
            //ViewBag.PostId = new SelectList(_db.Posts, "Id", "Description");
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CateringOrder cateringOrder)
        {
            cateringOrder.User = db.Users.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.CateringOrders.Add(cateringOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PlaceOrder(int id)
        {
            var thisProduct = db.CateringOrders.FirstOrDefault(products => products.CateringOrderId == id);
            ViewBag.CateringProductId = new SelectList(db.CateringProducts, "CateringProductId", "Name");

            ViewBag.List = db.CateringProducts.ToList();

            return View(thisProduct);
        }


        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {

            db.Orders.Add(order);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult OrderConfirmation(int id)
        {
            var thisCateringOrder = db.CateringOrders.FirstOrDefault(cateringOrders => cateringOrders.CateringOrderId == id);
            ViewBag.CateringProduct = db.CateringOrders
                .Include(cateringOrder => cateringOrder.Order)
                .ThenInclude(order => order.CateringProduct)
                .Where(cateringOrder => cateringOrder.CateringOrderId == id).ToList();
            return View(thisCateringOrder);

        }

    }
}
