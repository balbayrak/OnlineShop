using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Repository.EfCore.Mapping;

namespace OnlineShop.Order.Persistence.Repositories.EfCore.Mapping
{
    public class OrderMap : BaseEntityMap<Domain.Models.Order>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Orders");

        }
    }
}
