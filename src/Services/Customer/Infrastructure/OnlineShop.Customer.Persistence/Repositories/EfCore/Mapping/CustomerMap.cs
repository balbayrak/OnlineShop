using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Persistence.Repository.EfCore.Mapping;

namespace OnlineShop.Customer.Persistence.Repositories.EfCore.Mapping
{
    public class CustomerMap : BaseEntityMap<Domain.Models.Customer>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Customer> builder)
        {
            base.Configure(builder);

            builder.ToTable("Customers");

            builder.OwnsOne(e => e.Address);

        }
    }
}
