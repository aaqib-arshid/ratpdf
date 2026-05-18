using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ratpdf.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpiId",
                table: "BrandingSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpiQrUrl",
                table: "BrandingSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpiId",
                table: "BrandingSettings");

            migrationBuilder.DropColumn(
                name: "UpiQrUrl",
                table: "BrandingSettings");
        }
    }
}
