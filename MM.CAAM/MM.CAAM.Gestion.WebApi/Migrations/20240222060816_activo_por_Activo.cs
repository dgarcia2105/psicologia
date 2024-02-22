using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class activoporActivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "activo",
                table: "TipoUsuario",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "Rol",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "GradoEducacion",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "Genero",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "EstadoVida",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "EstadoCivil",
                newName: "Activo");

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "TipoUsuario",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "Rol",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "GradoEducacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "Genero",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "EstadoVida",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "EstadoCivil",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "TipoUsuario",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Rol",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "GradoEducacion",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Genero",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "EstadoVida",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "EstadoCivil",
                newName: "activo");

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "TipoUsuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "Rol",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "GradoEducacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "Genero",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "EstadoVida",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "activo",
                table: "EstadoCivil",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
