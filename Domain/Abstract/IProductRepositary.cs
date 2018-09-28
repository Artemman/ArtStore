using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IProductRepositary
    {
         IQueryable<Product> Products { get; }
         IQueryable<Category> Categories { get; }
    }
}
