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
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Category> builder)
        {
            
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();

            builder.HasMany(x => x.ProductCategories)
                     .WithOne(x => x.Category)
                     .HasForeignKey(x => x.CategoryId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Name);

        }
    }
}
