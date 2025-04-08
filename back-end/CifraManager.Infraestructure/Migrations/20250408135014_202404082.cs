using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CifraManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class _202404082 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PdfId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfId",
                table: "Songs");
        }
    }
}
