using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSite.Models;

namespace ECommerceSite.Controllers
{
    public class ItemsController : Controller
    {
        public ActionResult ItemIndex()
        {
            var list = new EcommerceEntities1();
            var items = list.Products.Where(i => i.Id != null);

            return View(items.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
         public ActionResult Edit(int id)
        {
            var list = new EcommerceEntities1();
            var item = list.Products.Where(i => i.Id == id && i.Id != null).First();

            return View(item);
        }
    }
}