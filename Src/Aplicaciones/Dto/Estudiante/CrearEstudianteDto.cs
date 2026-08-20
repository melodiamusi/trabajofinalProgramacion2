using System.ComponentModel.DataAnnotations;

namespace SistemaAula.Aplicaciones.Dto.Estudiante
{
    public class CrearEstudianteDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Matricula { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}