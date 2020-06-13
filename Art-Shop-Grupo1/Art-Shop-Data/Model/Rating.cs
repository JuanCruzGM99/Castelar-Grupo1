using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Rating : Identity
    {

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Stars { get; set; }


        public Rating()
        {

        }

        public Rating(int id, int UserId, int ProductId, int Star, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {
            this.Id = id;
            this.UserId = UserId;
            this.ProductId = ProductId;
            this.Stars = Star;
            this.CreateOn = CreateOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }
    }
}
