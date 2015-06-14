using ECommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var list = new EcommerceEntities1();
            var items = list.Products.Take(3);

            return View(items.ToList());
            //return View();
        }

        public ActionResult Market()
        {
            return View();
        }
    }
}