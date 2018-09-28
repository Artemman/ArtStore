using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ProductListViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}