using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFProductRepositary : IProductRepositary

    {
        private ArtStoreContext context = new ArtStoreContext();
        public IQueryable<Product> Products { get => context.Products; }
        public IQueryable<Category> Categories { get => context.Categories; }
    }
    
}
