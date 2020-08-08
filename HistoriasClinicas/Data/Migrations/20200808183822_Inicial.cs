using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HistoriasClinicas.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrativos",
                columns: table => new
                {
                    CodEmpleado = table.Column<string>(nullable: false),
                    Dni = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Nacimiento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrativos", x => x.CodEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    CodEmpleado = table.Column<string>(nullable: false),
                    Dni = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Nacimiento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Especialidad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.CodEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dni = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Nacimiento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    HistoriaClinicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.HistoriaClinicaId);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epicrisis",
                columns: table => new
                {
                    EpicrisisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HistoricaClinicaId = table.Column<int>(nullable: false),
                    HistoriaClinicaId = table.Column<int>(nullable: true),
                    HoraCarga = table.Column<DateTime>(nullable: false),
                    Diagnostico = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epicrisis", x => x.EpicrisisId);
                    table.ForeignKey(
                        name: "FK_Epicrisis_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "HistoriaClinicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodios",
                columns: table => new
                {
                    EpisodioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Motivo = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    EstadoAbierto = table.Column<bool>(nullable: false),
                    EpicrisisId = table.Column<int>(nullable: false),
                    HistoriaClinicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodios", x => x.EpisodioId);
                    table.ForeignKey(
                        name: "FK_Episodios_Epicrisis_EpicrisisId",
                        column: x => x.EpicrisisId,
                        principalTable: "Epicrisis",
                        principalColumn: "EpicrisisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Episodios_HistoriasClinicas_HistoriaClinicaId",
                        column: x => x.HistoriaClinicaId,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "HistoriaClinicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    NotaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false),
                    EpicrisisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.NotaId);
                    table.ForeignKey(
                        name: "FK_Notas_Epicrisis_EpicrisisId",
                        column: x => x.EpicrisisId,
                        principalTable: "Epicrisis",
                        principalColumn: "EpicrisisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recomendaciones",
                columns: table => new
                {
                    RecomendacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false),
                    EpicrisisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendaciones", x => x.RecomendacionId);
                    table.ForeignKey(
                        name: "FK_Recomendaciones_Epicrisis_EpicrisisId",
                        column: x => x.EpicrisisId,
                        principalTable: "Epicrisis",
                        principalColumn: "EpicrisisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evoluciones",
                columns: table => new
                {
                    EvolucionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodEmpleado = table.Column<string>(nullable: true),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFin = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    EstadoAbierto = table.Column<bool>(nullable: false),
                    EpisodioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evoluciones", x => x.EvolucionId);
                    table.ForeignKey(
                        name: "FK_Evoluciones_Medicos_CodEmpleado",
                        column: x => x.CodEmpleado,
                        principalTable: "Medicos",
                        principalColumn: "CodEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evoluciones_Episodios_EpisodioId",
                        column: x => x.EpisodioId,
                        principalTable: "Episodios",
                        principalColumn: "EpisodioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Epicrisis_HistoriaClinicaId",
                table: "Epicrisis",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_EpicrisisId",
                table: "Episodios",
                column: "EpicrisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_HistoriaClinicaId",
                table: "Episodios",
                column: "HistoriaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_CodEmpleado",
                table: "Evoluciones",
                column: "CodEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_EpisodioId",
                table: "Evoluciones",
                column: "EpisodioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_PacienteId",
                table: "HistoriasClinicas",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_EpicrisisId",
                table: "Notas",
                column: "EpicrisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Recomendaciones_EpicrisisId",
                table: "Recomendaciones",
                column: "EpicrisisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrativos");

            migrationBuilder.DropTable(
                name: "Evoluciones");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Recomendaciones");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Episodios");

            migrationBuilder.DropTable(
                name: "Epicrisis");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
