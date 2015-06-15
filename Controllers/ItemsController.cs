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
        ProductRepo repository = new ProductRepo();

        public ActionResult ItemIndex()
        {
            var list = repository.GetAllProducts();
            var items = list.Where(i => i.Id != null);

            return View(items.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var list = repository.GetAllProducts();
            var items = list.Where(i => i.Id == id && i.Id != null).First();

            return View(items);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            
            return View();
        }
    }
}