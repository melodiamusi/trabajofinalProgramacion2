using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Infrastructure.Repositorio
{
    public class CursoRepositorio : GenericRepositorio<Curso>
    {
        public CursoRepositorio(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}