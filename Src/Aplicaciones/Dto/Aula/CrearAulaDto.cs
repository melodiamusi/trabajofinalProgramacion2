namespace SistemaAula.Aplicaciones.Dto.Aula;

public class CrearAulaDto
{
    public string Nombre { get; set; } = string.Empty;
    public int Capacidad { get; set; } // <-- Propiedad requerida
}