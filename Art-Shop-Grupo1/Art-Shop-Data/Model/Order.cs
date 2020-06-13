using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Order : Identity
    {

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public float TotalPrice { get; set; }

        public int OrderNumber { get; set; }

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
            this.CreateOn = CreateOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;
        }
    }
}
