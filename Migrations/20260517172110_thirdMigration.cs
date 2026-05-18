using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ratpdf.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "ClientGstin",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HsnSacCode",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfSupply",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxType",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YourGstin",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HsnSacCode",
                table: "InvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientGstin",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "HsnSacCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PlaceOfSupply",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TaxType",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "YourGstin",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "HsnSacCode",
                table: "InvoiceItems");
        }
    }
}
