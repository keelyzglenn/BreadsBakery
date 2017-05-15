using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreadsBakery.Migrations
{
    public partial class Prepopulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CateringProducts");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServingSize",
                table: "CateringProducts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "CateringProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CateringProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServingSize",
                table: "CateringProducts",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "CateringProducts",
                nullable: false);
        }
    }
}
