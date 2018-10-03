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
    public class HomeController : Controller
    {
        private IProductRepositary db;
        
        int pageSize = 3;
        int[] pageSizes = new int[] { 9, 12, 16, 20, 30 };
        public HomeController(IProductRepositary _db)
        {
            db = _db;
            
        }
        public ActionResult Index(string category, int? userPageSize,int page = 1)
        {
            ViewBag.Sizes = pageSizes;
            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPgae = userPageSize == null ? pageSize : (int)userPageSize,
                TotalItems = category == null ?
                 db.Products.Count() :
                 db.Products.Where(e => e.Category == category).Count()
            };
           
            if (Request.IsAjaxRequest())
            {
                if (page <= pagingInfo.TotalPages)
                    return PartialView("_ListProduct", GetItemsPage(page, category));
                else return null;
            }
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = GetItemsPage(page, category),
                pagingInfo = pagingInfo,
                CurrentCategory = category 
            };
            return View(model);
        }
        private IQueryable<Product> GetItemsPage(int page, string category)
        {
            return db.Products.Where(x => category == null || x.Category == category).OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize);
        }




    }
}