using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CifraManager.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class _20250408Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThemeName",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThemeName",
                table: "Songs");
        }
    }
}
