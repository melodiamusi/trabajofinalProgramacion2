namespace SistemaAula.Aplicaciones.Dto.Reserva;

public class ReservaDto
{
    public int Id { get; set; }

    public int AulaId { get; set; }
    public string AulaNombre { get; set; } = string.Empty;

    public int HorarioId { get; set; }
    public string HorarioDetalle { get; set; } = string.Empty;

    public int ProfesorId { get; set; }
    public string ProfesorNombre { get; set; } = string.Empty;

    public DateTime FechaReserva { get; set; }

    public string Motivo { get; set; } = string.Empty;

    public string Estado { get; set; } = "Pendiente";
}

public class CrearReservaDto
{
    public int AulaId { get; set; }

    public int HorarioId { get; set; }

    public int ProfesorId { get; set; }

    public DateTime FechaReserva { get; set; }

    public string Motivo { get; set; } = string.Empty;
}