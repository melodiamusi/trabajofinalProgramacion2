using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Infrastructure.Repositorio
{
    public class AulaRepositorio : GenericRepositorio<Aula>
    {
        public AulaRepositorio(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}