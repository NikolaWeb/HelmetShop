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
    public class BrandConfiguration : EntityConfiguration<Brand>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Brand)
                   .HasForeignKey(x => x.BrandId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
