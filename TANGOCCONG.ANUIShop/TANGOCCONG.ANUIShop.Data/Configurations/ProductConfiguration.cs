using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TANGOCCONG.ANUIShop.Data.Entities;

namespace TANGOCCONG.ANUIShop.Data.Configuarations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        }
    }
}
