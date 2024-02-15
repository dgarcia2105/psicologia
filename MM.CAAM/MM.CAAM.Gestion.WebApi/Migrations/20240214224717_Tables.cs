using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.CAAM.Gestion.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoVida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoVida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradoEducacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoEducacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoAlimenticios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAlimenticios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeccionesSupermercado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeccionesSupermercado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGrupoId = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposGrupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGrupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombrePerfil = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerfilNombreArchivo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Profesion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Ocupacion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    CP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Latitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesHeredofamiliares = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesPatologicosPersonales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AntecedentesNoPatologicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecomendadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeguroMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAcceso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BearerToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    GeneroId = table.Column<int>(type: "int", nullable: true),
                    GradoEducacionId = table.Column<int>(type: "int", nullable: true),
                    EstadoVidaId = table.Column<int>(type: "int", nullable: true),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: true),
                    TipoUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_EstadoCivil_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCivil",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_EstadoVida_EstadoVidaId",
                        column: x => x.EstadoVidaId,
                        principalTable: "EstadoVida",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_GradoEducacion_GradoEducacionId",
                        column: x => x.GradoEducacionId,
                        principalTable: "GradoEducacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresionArterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrecuenciaCardiaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrecuenciaRespiratoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComentarioSignosVitales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Glucosa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PadecimientoActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExploracionFisica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TratamientoMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstudiosSolicitadosLaboratorioGabinete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartaBajoConsentimientoInformado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotasEvolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturacionOxigeno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas",
                column: "UsuarioId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "GrupoAlimenticios");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "SeccionesSupermercado");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "TiposGrupo");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "EstadoVida");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "GradoEducacion");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
