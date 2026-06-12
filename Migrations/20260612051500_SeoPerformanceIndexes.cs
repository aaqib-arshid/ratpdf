using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ratpdf.Migrations
{
    /// <inheritdoc />
    public partial class SeoPerformanceIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId_Status_CurrentPeriodEnd",
                table: "Subscriptions",
                columns: new[] { "UserId", "Status", "CurrentPeriodEnd" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId_CreatedAt",
                table: "Invoices",
                columns: new[] { "UserId", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId_Status_CurrentPeriodEnd",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId_CreatedAt",
                table: "Invoices");
        }
    }
}
