namespace SistemaAula.Blazor.Models;

public class CursoModel
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Profesor { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;
    public int? AulaId { get; set; }
}