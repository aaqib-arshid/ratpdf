using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ratpdf.Migrations
{
    /// <inheritdoc />
    public partial class AddPdfJobRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdfJobRecords",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    JobKind = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    BlobName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OutputFileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    OutputMimeType = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    InputBytes = table.Column<long>(type: "bigint", nullable: true),
                    OutputBytes = table.Column<long>(type: "bigint", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfJobRecords", x => x.JobId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PdfJobRecords_UpdatedUtc",
                table: "PdfJobRecords",
                column: "UpdatedUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PdfJobRecords_UserId",
                table: "PdfJobRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PdfJobRecords");
        }
    }
}
