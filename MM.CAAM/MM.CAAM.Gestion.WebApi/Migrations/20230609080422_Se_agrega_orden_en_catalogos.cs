using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Seagregaordenencatalogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "UnidadesMedida",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "TiposGrupo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "SeccionesSupermercado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "Proveedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Orden",
                table: "GrupoAlimenticios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orden",
                table: "UnidadesMedida");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "TiposGrupo");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "SeccionesSupermercado");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "Orden",
                table: "GrupoAlimenticios");
        }
    }
}
