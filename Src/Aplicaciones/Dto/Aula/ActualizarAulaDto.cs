using System.ComponentModel.DataAnnotations;

namespace Aplicaciones.Dto.Aula
{
    public class ActualizarAulaDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del aula es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}