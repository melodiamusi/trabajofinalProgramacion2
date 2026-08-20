namespace SistemaAula.Domain.Entidades;

public class Horario
{
    public int Id { get; set; }
    public string DiaSemana { get; set; } = string.Empty;
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}