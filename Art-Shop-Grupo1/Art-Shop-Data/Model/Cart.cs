using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Cart : Identity
    {

        public String Cookie { get; set; }

        public DateTime CartDate { get; set; }

        [DisplayName("Cantidad")]

        public int ItemCount { get; set; }

        public Cart()
        {
                
        }

        public Cart(int id, String Cookie, DateTime CartDate, int ItemCount , DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {
            this.Id = id;
            this.Cookie = Cookie;
            this.CartDate = CartDate;
            this.ItemCount = ItemCount;
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }
    }
}
