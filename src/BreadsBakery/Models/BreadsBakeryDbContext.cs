using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BreadsBakery.Models;

namespace Portfolio.Models
{
    public class PortfolioDbContext : DbContext
    {
        public virtual DbSet<StoreProduct> StoreProducts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<CateringProduct> CateringProducts { get; set; }

        public virtual DbSet<CateringOrder> CateringOrders { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public PortfolioDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BreadsBakery;integrated security=True");
        }

        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(t => new { t.CateringProductId, t.CateringOrderId });


            base.OnModelCreating(builder);
        }

    }
}