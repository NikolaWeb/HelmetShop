using HelmetShop.Domain;
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
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}
