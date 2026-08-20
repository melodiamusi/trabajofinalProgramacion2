namespace SistemaAula.Blazor.Models;

public class ProfesorModel
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Correo { get => Email; set => Email = value; }
    public string Especialidad { get; set; } = string.Empty;
}