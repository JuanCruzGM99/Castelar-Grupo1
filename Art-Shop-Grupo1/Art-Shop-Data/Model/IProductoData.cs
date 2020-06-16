using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Art_Shop_Data.Model
{
        public interface IProductoData
        {


            IEnumerable<Product> GetAll();

        }
    

}
