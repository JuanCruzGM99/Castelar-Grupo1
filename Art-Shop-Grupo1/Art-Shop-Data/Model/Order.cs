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

        [DisplayName("Fecha de la orden")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Precio Total")]
        public float TotalPrice { get; set; }

        [DisplayName("Numero de orden")]
        public int OrderNumber { get; set; }

        [DisplayName("Cantidad del item")]
        public int ItemCount { get; set; }

        public Order()
        {
                
        }

        public Order(int id, int UserId, DateTime OrderDate, float TotalPrice, int OrderNumber, int Itemcount, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {

            this.Id = id;
            this.UserId = UserId;
            this.OrderDate = OrderDate;
            this.TotalPrice = TotalPrice;
            this.OrderNumber = OrderNumber;
            this.ItemCount = ItemCount;
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;
        }
    }
}
