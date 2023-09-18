using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ocupacion",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ocupacion",
                table: "Usuarios");
        }
    }
}
