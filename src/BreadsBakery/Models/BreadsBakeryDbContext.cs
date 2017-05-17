using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BreadsBakery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BreadsBakery.Models
{
    public class BreadsBakeryDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<StoreProduct> StoreProducts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<CateringProduct> CateringProducts { get; set; }

        public virtual DbSet<CateringOrder> CateringOrders { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BreadsBakery;integrated security=True");
        }

        public BreadsBakeryDbContext()
        {
        }

        public BreadsBakeryDbContext(DbContextOptions<BreadsBakeryDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Order>()
            //    .HasKey(t => new { t.CateringProductId, t.CateringOrderId });


            base.OnModelCreating(builder);
        }

    }
}