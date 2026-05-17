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
            migrationBuilder.DropTable(
                name: "ImgBgPayments");

            migrationBuilder.DropTable(
                name: "ImgBgUserSubscriptions");

            migrationBuilder.DropTable(
                name: "ImgBgUserUsages");

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

            migrationBuilder.CreateTable(
                name: "ImgBgPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RazorpayOrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazorpayPaymentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgBgPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImgBgUserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgBgUserSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImgBgUserUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeDownloadsUsed = table.Column<int>(type: "int", nullable: false),
                    LastResetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgBgUserUsages", x => x.Id);
                });
        }
    }
}
