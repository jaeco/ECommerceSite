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

        [Authorize(Roles = "admin")]
        public ActionResult ItemIndex()
        {
            var list = repository.GetAllProducts();
            var items = list.Where(i => i.Id != null);

            return View(items.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            Product product = new Product();
            {
                product.Name = "New Item";
            }

            return View(product);
        }

        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles="admin")]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    UpdateModel(product);

                    repository.Add(product);
                    repository.Save();

                    return RedirectToAction("Product", "Market", new { id = product.Id });
                }
                catch
                {
                    ModelState.AddRuleViolations(product.GetRuleViolations());
                }

            }
            return View(product);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var list = repository.GetAllProducts();
            var items = list.Where(i => i.Id == id && i.Id != null).First();

            return View(items);
        }

        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles = "admin")]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            //Get existing product
            Product product = repository.GetProduct(id);


            try
            {
                //Update existing product  (verbose)
                //product.Name = Request.Form["Name"];
                //product.Price = Request.Form["Price"];
                //product.Description = Request.Form["Description"];
                //product.Image = Request.Form["Image"];
                //product.Features = Request.Form["Features"];

                //Update existing product  (simple)
                UpdateModel(product);

                //Save changes to database
                repository.Save();

                //Return to item index
                return RedirectToAction("ItemIndex", "Items");
            }
            catch
            {
                ModelState.AddRuleViolations(product.GetRuleViolations());

                return View(product);
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Product product = repository.GetProduct(id);

            if(product != null)
            {
                return View(product);
            }
            else
            {
                return View("NotFound");
            }
        }

        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles="admin")]
        public ActionResult Delete(int id, string confirmButton)
        {
            Product product = repository.GetProduct(id);

            if (product != null)
            {
                repository.Delete(product);
                repository.Save();

                return View("Deleted");
            }
            else
            {
                return RedirectToAction("ItemIndex","Items");
            }
        }
    }
}