using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BreadsBakery.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CateringProducts",
                columns: table => new
                {
                    CateringProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ServingSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringProducts", x => x.CateringProductId);
                    table.ForeignKey(
                        name: "FK_CateringProducts_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    StoreProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => x.StoreProductId);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CateringOrders",
                columns: table => new
                {
                    CateringOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    DateNeeded = table.Column<string>(nullable: true),
                    DateTaken = table.Column<string>(nullable: true),
                    Delivery = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ServingRange = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringOrders", x => x.CateringOrderId);
                    table.ForeignKey(
                        name: "FK_CateringOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    CateringProductId = table.Column<int>(nullable: false),
                    CateringOrderId = table.Column<int>(nullable: false),
                    CateringOrderId1 = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => new { x.CateringProductId, x.CateringOrderId });
                    table.ForeignKey(
                        name: "FK_Orders_CateringOrders_CateringOrderId1",
                        column: x => x.CateringOrderId1,
                        principalTable: "CateringOrders",
                        principalColumn: "CateringOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_CateringProducts_CateringProductId",
                        column: x => x.CateringProductId,
                        principalTable: "CateringProducts",
                        principalColumn: "CateringProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CateringOrders_UserId",
                table: "CateringOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CateringProducts_DepartmentId",
                table: "CateringProducts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CateringOrderId1",
                table: "Orders",
                column: "CateringOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CateringProductId",
                table: "Orders",
                column: "CateringProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_DepartmentId",
                table: "StoreProducts",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.DropTable(
                name: "CateringOrders");

            migrationBuilder.DropTable(
                name: "CateringProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
