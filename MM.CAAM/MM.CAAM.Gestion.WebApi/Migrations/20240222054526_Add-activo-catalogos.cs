using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Addactivocatalogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "TipoUsuario",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Rol",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "GradoEducacion",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Genero",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "EstadoVida",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "EstadoCivil",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activo",
                table: "TipoUsuario");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "GradoEducacion");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "EstadoVida");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "EstadoCivil");
        }
    }
}
