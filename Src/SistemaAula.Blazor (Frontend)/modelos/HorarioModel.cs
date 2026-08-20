namespace SistemaAula.Blazor.Models;

public class HorarioModel
{
    public int Id { get; set; }
    public string DiaSemana { get; set; } = "Lunes";
    public TimeSpan HoraInicio { get; set; } = new TimeSpan(8, 0, 0);
    public TimeSpan HoraFin { get; set; } = new TimeSpan(10, 0, 0);
    public string Descripcion => $"{DiaSemana} ({HoraInicio:hh\\:mm} - {HoraFin:hh\\:mm})";
}