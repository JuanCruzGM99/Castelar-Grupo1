using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Art_Shop_Data.Model
{
    public class Product : Identity
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public int ArtistId { get; set; }

        public String Image { get; set; }

        public Double Price { get; set; }

        public int QuantitySold { get; set; }

        public Double AvgStars { get; set; }


        public Product()
        {
           
        }

        public Product(int id, String Title, String Description, int ArtistaId, String Image, float Price, int QuantitySold, float AvgStars, DateTime CreatedOn, String CreatedBy, DateTime ChangedOn, String ChangedBy)
        {

            this.Id = id;
            this.Title = Title;
            this.Description = Description;
            this.ArtistId = ArtistaId;
            this.Image = Image;
            this.Price = Price;
            this.QuantitySold = QuantitySold;
            this.AvgStars = AvgStars;
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }

    }
}
