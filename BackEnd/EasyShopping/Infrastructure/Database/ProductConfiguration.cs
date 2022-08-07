using EasyShopping.Core.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShopping.Infrastructure.Database
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(200);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ProductPhoto).IsRequired();
            builder.Property(x => x.ProductPhotoUrl).IsRequired();
            builder.HasOne(x => x.ProductBrand).WithMany().HasForeignKey(x=>x.ProductBrandId);
            builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(x=>x.ProductTypeId);
        }
    }
}
