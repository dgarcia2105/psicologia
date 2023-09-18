using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class FIxreligion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Religión",
                table: "Usuarios",
                newName: "Religion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "Usuarios",
                newName: "Religión");
        }
    }
}
