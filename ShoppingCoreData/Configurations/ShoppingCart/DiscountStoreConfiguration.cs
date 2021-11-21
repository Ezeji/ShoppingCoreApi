using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCoreData.Configurations.ShoppingCart
{
    public class DiscountStoreConfiguration : IEntityTypeConfiguration<DiscountStore>
    {
        public void Configure(EntityTypeBuilder<DiscountStore> entity)
        {
            entity.ToTable("DiscountStore");

            entity.Property(e => e.Sku).HasColumnName("SKU");
        }
    }
}
