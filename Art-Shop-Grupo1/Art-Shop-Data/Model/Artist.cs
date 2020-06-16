using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Artist : Identity
    {

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String LifeSpan { get; set; }

        public String Country { get; set; }

        public String Description { get; set; }

        public int TotalProducts { get; set; }

        public Artist()
        {

        }

        public Artist(int id, String FirstName, String LifeSpan, String Country, String Description, int TotalProducts, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {

            this.Id = id;
            this.FirstName = FirstName;
            this.LifeSpan = LifeSpan;
            this.Country = Country;
            this.Description = Description;
            this.TotalProducts = TotalProducts;
            this.CreateOn = CreateOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }

    }
}
