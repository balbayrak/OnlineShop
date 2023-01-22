using OnlineShop.Order.Domain.Models;
using OnlineShop.Persistence.Repository.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Order.Persistence.Repositories.EfCore.Context
{
    public class OrderDbContext : CoreDbContext
    {
        public OrderDbContext()
        {
        }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Domain.Models.Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
