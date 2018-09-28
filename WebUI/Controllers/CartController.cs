using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepositary db;
        public CartController(IProductRepositary _db)
        {
            db = _db;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel() { Cart = cart, returnUrl = returnUrl });
        }

        // GET: Cart
        public RedirectToRouteResult AddToCart (Cart cart, int productId, string returnUrl)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if(product!=null)
            {
                cart.AddItem(product,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = db.Products
            .FirstOrDefault(x=>x.Id == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        
    }
}