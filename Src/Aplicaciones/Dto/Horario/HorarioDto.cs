namespace SistemaAula.Aplicaciones.Dto.Horario;

public class HorarioDto
{
    public int Id { get; set; }
    public string DiaSemana { get; set; } = string.Empty;
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
    public string Descripcion => $"{DiaSemana} ({HoraInicio:hh\\:mm} - {HoraFin:hh\\:mm})";
}

public class CrearHorarioDto
{
    public string DiaSemana { get; set; } = string.Empty;
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}