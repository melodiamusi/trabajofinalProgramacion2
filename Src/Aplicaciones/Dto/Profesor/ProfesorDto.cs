namespace SistemaAula.Aplicaciones.Dto.Profesor;

public class CrearProfesorDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
}

public class ProfesorDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
}