using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Infrastructure.Repositorio
{
    public class EstudianteRepositorio : GenericRepositorio<Estudiante>, IEstudianteRepositorio
    {
        public EstudianteRepositorio(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}