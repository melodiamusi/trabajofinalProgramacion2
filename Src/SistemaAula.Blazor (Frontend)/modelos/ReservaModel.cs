namespace SistemaAula.Blazor.Models;

public class ReservaModel
{
    public int Id { get; set; }
    public int AulaId { get; set; }
    public string AulaNombre { get; set; } = string.Empty;
    public int HorarioId { get; set; }
    public string HorarioDetalle { get; set; } = string.Empty;

    // <-- Esta propiedad es obligatoria para el @bind
    public int ProfesorId { get; set; }
    public string ProfesorNombre { get; set; } = string.Empty;

    public DateTime FechaReserva { get; set; } = DateTime.Today;
    public string Motivo { get; set; } = string.Empty;
    public string Estado { get; set; } = "Pendiente";
}
