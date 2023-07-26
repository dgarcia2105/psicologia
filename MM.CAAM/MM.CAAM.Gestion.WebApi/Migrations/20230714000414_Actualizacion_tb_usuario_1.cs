using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class Actualizaciontbusuario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BearerToken",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CP",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAcceso",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombrePerfil",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerfilNombreArchivo",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profesion",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "BearerToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CP",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaAcceso",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NombrePerfil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PerfilNombreArchivo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Profesion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");
        }
    }
}
