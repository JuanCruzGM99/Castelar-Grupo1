﻿using Art_Shop_Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_Shop_Data.Services
{
    public partial class ArtShopDbContext : DbContext
    {
        public ArtShopDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<ArtShopDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        /// DbSet Artist se utiliza para representar una tabla.
        public virtual DbSet<Artist> Artist { get; set; }

        /// DbSet Product se utiliza para representar una tabla.
        public virtual DbSet<Product> Product { get; set; }
        /// DbSet Product se utiliza para representar una tabla.
        public virtual DbSet<Error> Error { get; set; }

        public System.Data.Entity.DbSet<Art_Shop_Data.Model.Cart> Carts { get; set; }
        public System.Data.Entity.DbSet<Art_Shop_Data.Model.CartItem> CartsItem { get; set; }
        public System.Data.Entity.DbSet<Art_Shop_Data.Model.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Art_Shop_Data.Model.OrderDetail> OrdersDetails { get; set; }

         public System.Data.Entity.DbSet<Art_Shop_Data.Model.OrderNumber> OrdersNumbers{ get; set; }
    }
}
