using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepositary db;
        public NavController(IProductRepositary _db)
        {
            db = _db;
        }
        // GET: Nav
        public PartialViewResult Menu()
        {
            return PartialView(db.Categories.Select(x=>x.Name).OrderBy(x=>x));
        }
    }
}