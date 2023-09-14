using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.Models.Migrations
{
    /// <inheritdoc />
    public partial class CompletandoInfoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AntecedentesHeredofamiliares",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AntecedentesNoPatologicos",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AntecedentesPatologicosPersonales",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartaBajoConsentimientoInformado",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioSignosVitales",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diagnostico",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstudiosSolicitadosLaboratorioGabinete",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExploracionFisica",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrecuenciaCardiaca",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrecuenciaRespiratoria",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotasDevolucion",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PadecimientoActual",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresionArterial",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperatura",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TratamientoMedico",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntecedentesHeredofamiliares",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AntecedentesNoPatologicos",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AntecedentesPatologicosPersonales",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CartaBajoConsentimientoInformado",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "ComentarioSignosVitales",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "Diagnostico",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "EstudiosSolicitadosLaboratorioGabinete",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "ExploracionFisica",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "FrecuenciaCardiaca",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "FrecuenciaRespiratoria",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "NotasDevolucion",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PadecimientoActual",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "PresionArterial",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "TratamientoMedico",
                table: "Consultas");
        }
    }
}
