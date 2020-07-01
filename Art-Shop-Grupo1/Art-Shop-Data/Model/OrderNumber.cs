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
                
        }

        public OrderNumber(int id, int Number, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {
            this.Id = id;
            this.Number = Number;
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }
    }
}
