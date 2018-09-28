using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        public List<CartLine> Lines = new List<CartLine>();

        public void AddItem(Product product,int quantity)
        {
            CartLine line = Lines.Where(x => x.Product.Id == product.Id).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product)
        {
            Lines.RemoveAll(x => x.Product.Id == product.Id);
        }
        public decimal TotalValue()
        {
            return Lines.Sum(x => x.Product.Price * x.Quantity);
        }
        public void Clear()
        {
            Lines.Clear();
        }

    }
}
