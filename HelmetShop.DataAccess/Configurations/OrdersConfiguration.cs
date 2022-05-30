using HelmetShop.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelmetShop.DataAccess.Configurations
{
    public class OrdersConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
