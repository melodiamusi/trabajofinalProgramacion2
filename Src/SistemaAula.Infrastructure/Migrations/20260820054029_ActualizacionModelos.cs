using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAula.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Aulas_AulaId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Profesores_ProfesorId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "Profesor");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "Estudiante");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Curso");

            migrationBuilder.RenameTable(
                name: "Aulas",
                newName: "Aula");

            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "Profesor",
                newName: "Especialidad");

            migrationBuilder.RenameColumn(
                name: "Creditos",
                table: "Curso",
                newName: "AulaId");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Curso",
                newName: "Profesor");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiante",
                table: "Estudiante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aula",
                table: "Aula",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Aula_AulaId",
                table: "Reservas",
                column: "AulaId",
                principalTable: "Aula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Profesor_ProfesorId",
                table: "Reservas",
                column: "ProfesorId",
                principalTable: "Profesor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Aula_AulaId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Profesor_ProfesorId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiante",
                table: "Estudiante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aula",
                table: "Aula");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Curso");

            migrationBuilder.RenameTable(
                name: "Profesor",
                newName: "Profesores");

            migrationBuilder.RenameTable(
                name: "Estudiante",
                newName: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "Curso",
                newName: "Cursos");

            migrationBuilder.RenameTable(
                name: "Aula",
                newName: "Aulas");

            migrationBuilder.RenameColumn(
                name: "Especialidad",
                table: "Profesores",
                newName: "Departamento");

            migrationBuilder.RenameColumn(
                name: "Profesor",
                table: "Cursos",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "AulaId",
                table: "Cursos",
                newName: "Creditos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Aulas_AulaId",
                table: "Reservas",
                column: "AulaId",
                principalTable: "Aulas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Profesores_ProfesorId",
                table: "Reservas",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
