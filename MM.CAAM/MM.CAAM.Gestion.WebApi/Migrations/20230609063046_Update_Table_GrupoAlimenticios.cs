using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableGrupoAlimenticios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadMedida",
                table: "UnidadMedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoGrupo",
                table: "TipoGrupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo",
                table: "Tipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeccionSupermercado",
                table: "SeccionSupermercado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoAlimenticio",
                table: "GrupoAlimenticio");

            migrationBuilder.RenameTable(
                name: "UnidadMedida",
                newName: "UnidadesMedida");

            migrationBuilder.RenameTable(
                name: "TipoGrupo",
                newName: "TiposGrupo");

            migrationBuilder.RenameTable(
                name: "Tipo",
                newName: "Tipos");

            migrationBuilder.RenameTable(
                name: "SeccionSupermercado",
                newName: "SeccionesSupermercado");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.RenameTable(
                name: "GrupoAlimenticio",
                newName: "GrupoAlimenticios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesMedida",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposGrupo",
                table: "TiposGrupo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeccionesSupermercado",
                table: "SeccionesSupermercado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoAlimenticios",
                table: "GrupoAlimenticios",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesMedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposGrupo",
                table: "TiposGrupo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeccionesSupermercado",
                table: "SeccionesSupermercado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoAlimenticios",
                table: "GrupoAlimenticios");

            migrationBuilder.RenameTable(
                name: "UnidadesMedida",
                newName: "UnidadMedida");

            migrationBuilder.RenameTable(
                name: "TiposGrupo",
                newName: "TipoGrupo");

            migrationBuilder.RenameTable(
                name: "Tipos",
                newName: "Tipo");

            migrationBuilder.RenameTable(
                name: "SeccionesSupermercado",
                newName: "SeccionSupermercado");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.RenameTable(
                name: "GrupoAlimenticios",
                newName: "GrupoAlimenticio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadMedida",
                table: "UnidadMedida",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoGrupo",
                table: "TipoGrupo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo",
                table: "Tipo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeccionSupermercado",
                table: "SeccionSupermercado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoAlimenticio",
                table: "GrupoAlimenticio",
                column: "Id");
        }
    }
}
