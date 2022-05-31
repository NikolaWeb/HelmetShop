using HelmetShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.DataAccess.Configurations
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Size).IsRequired().HasMaxLength(5);

            builder.HasMany(x => x.ProductCategories)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
