using System.ComponentModel.DataAnnotations;

namespace Aplicaciones.Dto.Curso
{
    public class ActualizarCursoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Profesor { get; set; } = string.Empty;

        [Required]
        public string Horario { get; set; } = string.Empty;
    }
}