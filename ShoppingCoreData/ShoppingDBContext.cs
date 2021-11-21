using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingCoreData.Configurations.ShoppingCart;
using ShoppingCoreData.Models;

#nullable disable

namespace ShoppingCoreData
{
    public partial class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext(DbContextOptions<ShoppingDBContext> options)
            : base(options)
        {
        }

        //ShoppingCart
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<DiscountStore> DiscountStores { get; set; }

        //Regenerate Models and DBContext using CodeFirst From Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SHOPPINGCART
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountStoreConfiguration());
        }

    }
}
