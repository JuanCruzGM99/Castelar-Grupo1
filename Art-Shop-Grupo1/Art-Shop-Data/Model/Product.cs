using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Art_Shop_Data.Model
{
    public class Product : Identity
    {
        [DisplayName("Titulo")]
        public String Title { get; set; }

        [DisplayName("Descripcion")]
        public String Description { get; set; }

        public int ArtistId { get; set; }

        [DisplayName("Imagen")]
        public String Image { get; set; }

        [DisplayName("Precio")]
        public Double Price { get; set; }

        [DisplayName("Cantidad vendida")]
        public int QuantitySold { get; set; }

        [DisplayName("Promedio de estrellas")]
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
