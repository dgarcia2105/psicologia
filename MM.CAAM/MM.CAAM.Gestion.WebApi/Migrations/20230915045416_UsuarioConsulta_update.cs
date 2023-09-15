using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioConsultaupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecomendadoPor",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religión",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeguroMedico",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaturacionOxigeno",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RecomendadoPor",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Religión",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SeguroMedico",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SaturacionOxigeno",
                table: "Consultas");
        }
    }
}
