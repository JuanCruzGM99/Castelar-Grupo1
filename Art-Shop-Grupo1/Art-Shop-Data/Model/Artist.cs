using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Model
{
    public class Artist : Identity
    {
        [Required]
        [DisplayName("Nombre")]
        public String FirstName { get; set; }
        [Required]
        [DisplayName("Apellido")]
        public String LastName { get; set; }
        [DisplayName("Activo desde")]
        public String LifeSpan { get; set; }
        [DisplayName("País")]
        public String Country { get; set; }
        [DisplayName("Descripción")]
        public String Description { get; set; }
        [DisplayName("Total de productos")]
        public int TotalProducts { get; set; }

        [NotMapped]
        [DisplayName("Nombre Completo")]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
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
            this.CreatedOn = CreatedOn;
            this.CreatedBy = CreatedBy;
            this.ChangedOn = ChangedOn;
            this.ChangedBy = ChangedBy;

        }

    }
}
