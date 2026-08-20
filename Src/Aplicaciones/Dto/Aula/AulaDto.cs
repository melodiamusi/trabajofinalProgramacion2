namespace SistemaAula.Aplicaciones.Dto.Aula;

public class AulaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Capacidad { get; set; } // <-- Agrega esta propiedad
}