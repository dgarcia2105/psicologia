using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class generoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoCivilId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoVidaId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradoEducacionId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "Usuarios",
                type: "nvarchar(240)",
                maxLength: 240,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsiarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoCivilId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstadoVidaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "GradoEducacionId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Notas",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsiarioId",
                table: "Usuarios");
        }
    }
}
