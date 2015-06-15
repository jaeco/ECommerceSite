using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceSite.Models;

namespace ECommerceSite.Models
{
    public class ProductRepo
    {
        private ProductDBDataContext db = new ProductDBDataContext();
        //private EcommerceEntities db = new EcommerceEntities();

        //Query methods

        
        //Get all products
        public IQueryable<Product> GetAllProducts()
        {
            return db.Products;
                   
        }

        //Get a single product by id
        public Product GetProduct(int id)
        {
            return db.Products.SingleOrDefault(i => i.Id == id  && i.Id != null);
        }

        //Insert/Delete Methods

        //Add method
        public void Add(Product product)
        {
            db.Products.InsertOnSubmit(product);
        }

        //Delete method
        public void Delete(Product product)
        {
            db.Products.DeleteOnSubmit(product);
        }

        //Persistence
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}