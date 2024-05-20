using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoComplessoID.Migrations
{
    /// <inheritdoc />
    public partial class migrazione4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Album",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nation",
                table: "Album",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Nation",
                table: "Album");
        }
    }
}
