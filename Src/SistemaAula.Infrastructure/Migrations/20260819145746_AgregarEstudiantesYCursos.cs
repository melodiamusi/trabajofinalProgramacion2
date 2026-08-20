using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAula.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEstudiantesYCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "Profesor",
                table: "Cursos",
                newName: "Codigo");

            migrationBuilder.AddColumn<int>(
                name: "Creditos",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creditos",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Cursos",
                newName: "Profesor");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
