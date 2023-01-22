using Microsoft.EntityFrameworkCore;
using OnlineShop.Persistence.Repository.EfCore.Context;

namespace OnlineShop.Customer.Persistence.Repositories.EfCore.Context
{
    public class CustomerDbContext : CoreDbContext
    {
        public CustomerDbContext()
        {
        }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Domain.Models.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
