using Domain;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class InfoController : Controller
    {
        private IProductRepositary db;

        public InfoController(IProductRepositary _db)
        {
            db = _db;
        }
        // GET: Info
        public ViewResult Index(int productId)
        {
            var product = db.Products.FirstOrDefault(x=>x.Id==productId);
            if (product != null)
            {
                var sameProducts = db.Products.Where(x => x.Category == product.Category && x.Id!=product.Id).Take(6);
               
                ProductInfo model = new ProductInfo() { Product = product, SameProducts = sameProducts };
                return View(model);
            }
                
            else return View("Error");
        }
    }
}