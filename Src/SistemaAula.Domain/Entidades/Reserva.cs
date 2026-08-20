namespace SistemaAula.Domain.Entidades;

public class Reserva
{
    public int Id { get; set; }
    public int AulaId { get; set; }
    public Aula? Aula { get; set; }

    public int? ProfesorId { get; set; }
    public Profesor? Profesor { get; set; }

    public int HorarioId { get; set; }
    public Horario? Horario { get; set; }

    public DateTime FechaReserva { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Estado { get; set; } = "Pendiente"; // "Pendiente", "Aprobada", "Rechazada"
}