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
        ProductRepo repository = new ProductRepo();

        public ActionResult Market()
        {
            var list = repository.GetAllProducts();
            var items = list.Where(i => i.Id != null);

            return View(items.ToList());
        }

        public ActionResult Product(int id)
        {
            return View(repository.GetProduct(id));
        }

        [Authorize(Roles="admin")]
        public ActionResult Edit(int id)
        {
            var list = repository.GetAllProducts();
            var item = list.Where(i => i.Id != null).First();

            return View(item);
        }
    }
}