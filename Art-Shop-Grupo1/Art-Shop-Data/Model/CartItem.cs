using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class CartItem : Identity
    {

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public CartItem()
        {

        }

        public CartItem(int id, int CartId, int ProductId, double Price, int Quantity, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {

            this.Id = id;
            this.CartId = CartId;
            this.ProductId = ProductId;
            this.Price = Price;
            this.Quantity = Quantity;
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;
        }
    }
}
