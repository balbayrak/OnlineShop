using OnlineShop.Order.Domain.Models;
using OnlineShop.Persistence.Repository.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Order.Persistence.Repositories.EfCore.Mapping
{
    public class OrderItemMap : BaseEntityMap<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderItems");

            builder.Property(p => p.OrderId).IsRequired();

            builder.Property(p => p.ProductId).IsRequired();

            builder.Property(p => p.TotalPrice).HasPrecision(18, 2);

            builder.HasOne(p => p.Order)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.OrderId);

        }
    }
}
