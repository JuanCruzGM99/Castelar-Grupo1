using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class OrderDetail : Identity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        
        public float Price { get; set; }

        public int Quantity { get; set; }

        public OrderDetail()
        {
                
        }

        public OrderDetail(int id, int OrderId, int ProductId, float Price, int Quantity, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {
            this.Id = id;
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.Price = Price;
            this.Quantity = Quantity;
            this.CreateOn = CreateOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;
        }
            
    }
}
