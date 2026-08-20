namespace SistemaAula.Domain.Entidades;

public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty; // <-- Agrega esta línea
    public string Matricula { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}