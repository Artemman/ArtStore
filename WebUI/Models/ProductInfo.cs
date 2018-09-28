using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ProductInfo
    {
        public Product Product { get; set; }
        public IQueryable<Product> SameProducts { get; set; }
    }
}