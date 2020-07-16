using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class OrderNumber : Identity
    {
        public int Number { get; set; }

        public OrderNumber()
        {
         
            this.CreatedOn = DateTime.Now;
          
            this.ChangedOn = DateTime.Now;
           

        }
    }
}
