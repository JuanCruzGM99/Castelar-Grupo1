using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class OrderDetail : Identity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [DisplayName("Precio")]
        public double Price { get; set; }

        [DisplayName("Cantidad")]
        public int Quantity { get; set; }

        public OrderDetail()
        {
                
        }

        public OrderDetail(int ProductId, double Price, int Quantity, String UserBy)
        {
           
            this.ProductId = ProductId;
            this.Price = Price;
            this.Quantity = Quantity;
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = "1";
            this.ChangedOn = DateTime.Now;
            this.ChangedBy = "1";
        }
            
    }
}
