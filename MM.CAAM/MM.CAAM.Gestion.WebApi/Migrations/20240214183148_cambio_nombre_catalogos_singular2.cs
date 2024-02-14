using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class cambionombrecatalogossingular2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VidaEstados",
                table: "VidaEstados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioTipos",
                table: "UsuarioTipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducacionGrados",
                table: "EducacionGrados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilEstados",
                table: "CivilEstados");

            migrationBuilder.RenameTable(
                name: "VidaEstados",
                newName: "EstadoVida");

            migrationBuilder.RenameTable(
                name: "UsuarioTipos",
                newName: "TipoUsuario");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.RenameTable(
                name: "EducacionGrados",
                newName: "GradoEducacion");

            migrationBuilder.RenameTable(
                name: "CivilEstados",
                newName: "EstadoCivil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoVida",
                table: "EstadoVida",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoUsuario",
                table: "TipoUsuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GradoEducacion",
                table: "GradoEducacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoCivil",
                table: "EstadoCivil",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoUsuario",
                table: "TipoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GradoEducacion",
                table: "GradoEducacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoVida",
                table: "EstadoVida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoCivil",
                table: "EstadoCivil");

            migrationBuilder.RenameTable(
                name: "TipoUsuario",
                newName: "UsuarioTipos");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "GradoEducacion",
                newName: "EducacionGrados");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.RenameTable(
                name: "EstadoVida",
                newName: "VidaEstados");

            migrationBuilder.RenameTable(
                name: "EstadoCivil",
                newName: "CivilEstados");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioTipos",
                table: "UsuarioTipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducacionGrados",
                table: "EducacionGrados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VidaEstados",
                table: "VidaEstados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilEstados",
                table: "CivilEstados",
                column: "Id");
        }
    }
}
