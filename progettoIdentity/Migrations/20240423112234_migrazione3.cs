using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoComplessoID.Migrations
{
    /// <inheritdoc />
    public partial class migrazione3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePDF",
                table: "Documento",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePDF",
                table: "Documento");
        }
    }
}
