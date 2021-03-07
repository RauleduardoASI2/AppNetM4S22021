using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppNetM4S22021.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    FacultadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.FacultadId);
                });

            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    GradoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradoNombre = table.Column<string>(nullable: true),
                    Seccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.GradoId);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    MaestroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.MaestroId);
                });


            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCurso = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    onLineMaestrosId = table.Column<int>(nullable: true),
                    presencialMaestrosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_Maestros_onLineMaestrosId",
                        column: x => x.onLineMaestrosId,
                        principalTable: "Maestros",
                        principalColumn: "MaestroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursos_Maestros_presencialMaestrosId",
                        column: x => x.presencialMaestrosId,
                        principalTable: "Maestros",
                        principalColumn: "MaestroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    DoB = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    Peso = table.Column<float>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    FacultadRefId = table.Column<int>(nullable: false),
                    NumeroRegistro = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    GradoId = table.Column<int>(nullable: false),
                    CursosCursoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Cursos_CursosCursoId",
                        column: x => x.CursosCursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Facultad_FacultadRefId",
                        column: x => x.FacultadRefId,
                        principalTable: "Facultad",
                        principalColumn: "FacultadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Grado_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grado",
                        principalColumn: "GradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionEstudiantes",
                columns: table => new
                {
                    IdDireccionEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion1 = table.Column<string>(nullable: true),
                    Direccion2 = table.Column<string>(nullable: true),
                    EstudiantesIdEstudiante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionEstudiantes", x => x.IdDireccionEstudiante);
                    table.ForeignKey(
                        name: "FK_DireccionEstudiantes_Estudiantes_EstudiantesIdEstudiante",
                        column: x => x.EstudiantesIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_onLineMaestrosId",
                table: "Cursos",
                column: "onLineMaestrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_presencialMaestrosId",
                table: "Cursos",
                column: "presencialMaestrosId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionEstudiantes_EstudiantesIdEstudiante",
                table: "DireccionEstudiantes",
                column: "EstudiantesIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CursosCursoId",
                table: "Estudiantes",
                column: "CursosCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_FacultadRefId",
                table: "Estudiantes",
                column: "FacultadRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_GradoId",
                table: "Estudiantes",
                column: "GradoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DireccionEstudiantes");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "Grado");

            migrationBuilder.DropTable(
                name: "Maestros");
        }
    }
}
