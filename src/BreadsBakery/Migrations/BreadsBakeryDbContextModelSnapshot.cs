using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BreadsBakery.Models;

namespace BreadsBakery.Migrations
{
    [DbContext(typeof(BreadsBakeryDbContext))]
    partial class BreadsBakeryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BreadsBakery.Models.CateringOrder", b =>
                {
                    b.Property<int>("CateringOrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("DateNeeded");

                    b.Property<string>("DateTaken");

                    b.Property<string>("Delivery");

                    b.Property<string>("PaymentMethod");

                    b.Property<int>("Price");

                    b.Property<string>("ServingRange");

                    b.Property<string>("Time");

                    b.Property<int>("UserId");

                    b.HasKey("CateringOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("CateringOrders");
                });

            modelBuilder.Entity("BreadsBakery.Models.CateringProduct", b =>
                {
                    b.Property<int>("CateringProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("ServingSize");

                    b.HasKey("CateringProductId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("CateringProducts");
                });

            modelBuilder.Entity("BreadsBakery.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("BreadsBakery.Models.Order", b =>
                {
                    b.Property<int>("CateringProductId");

                    b.Property<int>("CateringOrderId");

                    b.Property<int?>("CateringOrderId1");

                    b.Property<int>("Quantity");

                    b.HasKey("CateringProductId", "CateringOrderId");

                    b.HasIndex("CateringOrderId1");

                    b.HasIndex("CateringProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BreadsBakery.Models.StoreProduct", b =>
                {
                    b.Property<int>("StoreProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("StoreProductId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("BreadsBakery.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BreadsBakery.Models.CateringOrder", b =>
                {
                    b.HasOne("BreadsBakery.Models.User", "User")
                        .WithMany("CateringOrder")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BreadsBakery.Models.CateringProduct", b =>
                {
                    b.HasOne("BreadsBakery.Models.Department", "Department")
                        .WithMany("CateringProduct")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BreadsBakery.Models.Order", b =>
                {
                    b.HasOne("BreadsBakery.Models.CateringOrder", "CateringOrder")
                        .WithMany("Order")
                        .HasForeignKey("CateringOrderId1");

                    b.HasOne("BreadsBakery.Models.CateringProduct", "CateringProduct")
                        .WithMany("Order")
                        .HasForeignKey("CateringProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BreadsBakery.Models.StoreProduct", b =>
                {
                    b.HasOne("BreadsBakery.Models.Department", "Department")
                        .WithMany("StoreProducts")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
