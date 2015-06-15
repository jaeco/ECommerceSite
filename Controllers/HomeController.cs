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
        ProductRepo repository = new ProductRepo();

        public ActionResult Index()
        {
            var list = repository.GetAllProducts();
            var items = list.Take(3);

            return View(items.ToList());
        }

        public ActionResult Market()
        {
            return View();
        }
    }
}