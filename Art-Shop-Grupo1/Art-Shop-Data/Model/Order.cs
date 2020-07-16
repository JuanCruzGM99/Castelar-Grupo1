using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Order : Identity
    {

        public int UserId { get; set; }
        public List<OrderDetail> Items { get; set; }
        [DisplayName("Fecha de la orden")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Precio Total")]
        public double TotalPrice { get; set; }

        [DisplayName("Numero de orden")]
        public int OrderNumber { get; set; }

        [DisplayName("Cantidad del item")]
        public int ItemCount { get; set; }

        public Order()
        {
                
        }

        public Order(String UserBy)
        {
            this.UserId = 1;
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = "1";
            this.ChangedOn = DateTime.Now;
            this.ChangedBy = "1";
        }
    }
}
