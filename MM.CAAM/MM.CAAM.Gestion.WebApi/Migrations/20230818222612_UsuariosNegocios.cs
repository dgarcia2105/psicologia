using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class UsuariosNegocios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocios_Usuarios_UsuarioId",
                table: "Negocios");

            migrationBuilder.DropIndex(
                name: "IX_Negocios_UsuarioId",
                table: "Negocios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Negocios");

            migrationBuilder.CreateTable(
                name: "UsuariosNegocios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NegocioId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosNegocios", x => new { x.UsuarioId, x.NegocioId });
                    table.ForeignKey(
                        name: "FK_UsuariosNegocios_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosNegocios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosNegocios_NegocioId",
                table: "UsuariosNegocios",
                column: "NegocioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosNegocios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Negocios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_UsuarioId",
                table: "Negocios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocios_Usuarios_UsuarioId",
                table: "Negocios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
