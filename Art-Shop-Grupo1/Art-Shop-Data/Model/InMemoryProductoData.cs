using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class InMemoryProductoData : IProductoData
    {

        readonly List<Product> productos;

        public InMemoryProductoData()
        {
            productos = new List<Product>()
            {
                new Product() { Id=1, Title= "Cuadro 1" },
                new Product() { Id=2, Title = "Cuadro 2" },
                new Product() { Id=3, Title= "Cuadro 3" },
            };

        }

        public IEnumerable<Product> GetAll()
        {
            return productos.OrderBy(o => o.Title);
        }

   
    }
}
