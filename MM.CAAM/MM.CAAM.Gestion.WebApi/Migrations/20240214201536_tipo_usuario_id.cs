using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class tipousuarioid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsiarioId",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoCivilId",
                table: "Usuarios",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstadoVidaId",
                table: "Usuarios",
                column: "EstadoVidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_GeneroId",
                table: "Usuarios",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_GradoEducacionId",
                table: "Usuarios",
                column: "GradoEducacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_EstadoCivil_EstadoCivilId",
                table: "Usuarios",
                column: "EstadoCivilId",
                principalTable: "EstadoCivil",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_EstadoVida_EstadoVidaId",
                table: "Usuarios",
                column: "EstadoVidaId",
                principalTable: "EstadoVida",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Genero_GeneroId",
                table: "Usuarios",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_GradoEducacion_GradoEducacionId",
                table: "Usuarios",
                column: "GradoEducacionId",
                principalTable: "GradoEducacion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_EstadoCivil_EstadoCivilId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_EstadoVida_EstadoVidaId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Genero_GeneroId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_GradoEducacion_GradoEducacionId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EstadoCivilId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EstadoVidaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_GeneroId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_GradoEducacionId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsiarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);
        }
    }
}
