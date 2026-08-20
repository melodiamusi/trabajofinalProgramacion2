namespace SistemaAula.Domain.Entidades
{
    public class Aula
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int Capacidad { get; set; }
    }
}