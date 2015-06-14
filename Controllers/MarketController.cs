using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSite.Models;

namespace ECommerceSite.Controllers
{
    public class MarketController : Controller
    {
        public ActionResult Market()
        {
            var list = new EcommerceEntities1();
            var items = list.Products.Where(i => i.Id != null);

            return View(items.ToList());
        }

        public ActionResult Product(int id)
        {
            var list = new EcommerceEntities1();
            var item = list.Products.Where(i => i.Id == id && i.Id != null).First();

            return View(item);
        }

        public ActionResult Edit(int id)
        {
            var list = new EcommerceEntities1();
            var item = list.Products.Where(i => i.Id == id && i.Id != null).First();

            return View(item);
        }
    }
}