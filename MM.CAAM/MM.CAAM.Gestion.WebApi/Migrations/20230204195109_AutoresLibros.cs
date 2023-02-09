using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AutoresLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutorLibro_Autores_AutorId",
                table: "AutorLibro");

            migrationBuilder.DropForeignKey(
                name: "FK_AutorLibro_Libros_LibroId",
                table: "AutorLibro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutorLibro",
                table: "AutorLibro");

            migrationBuilder.RenameTable(
                name: "AutorLibro",
                newName: "AutoresLibros");

            migrationBuilder.RenameIndex(
                name: "IX_AutorLibro_LibroId",
                table: "AutoresLibros",
                newName: "IX_AutoresLibros_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoresLibros",
                table: "AutoresLibros",
                columns: new[] { "AutorId", "LibroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AutoresLibros_Autores_AutorId",
                table: "AutoresLibros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoresLibros_Libros_LibroId",
                table: "AutoresLibros",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoresLibros_Autores_AutorId",
                table: "AutoresLibros");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoresLibros_Libros_LibroId",
                table: "AutoresLibros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoresLibros",
                table: "AutoresLibros");

            migrationBuilder.RenameTable(
                name: "AutoresLibros",
                newName: "AutorLibro");

            migrationBuilder.RenameIndex(
                name: "IX_AutoresLibros_LibroId",
                table: "AutorLibro",
                newName: "IX_AutorLibro_LibroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutorLibro",
                table: "AutorLibro",
                columns: new[] { "AutorId", "LibroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AutorLibro_Autores_AutorId",
                table: "AutorLibro",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutorLibro_Libros_LibroId",
                table: "AutorLibro",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
