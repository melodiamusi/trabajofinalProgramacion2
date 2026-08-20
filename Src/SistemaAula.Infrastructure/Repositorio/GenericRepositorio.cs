using Microsoft.EntityFrameworkCore;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Infrastructure.Repositorio
{
    public class GenericRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepositorio(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Obtener todos los registros
        public List<T> ObtenerTodos()
        {
            return _dbSet.ToList();
        }

        // Obtener un registro por Id
        public T? ObtenerPorId(int id)
        {
            return _dbSet.Find(id);
        }

        // Agregar un registro
        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
            _context.SaveChanges();
        }

        // Actualizar un registro
        public void Actualizar(T entidad)
        {
            _dbSet.Update(entidad);
            _context.SaveChanges();
        }

        // Eliminar un registro por Id
        public void Eliminar(int id)
        {
            var entidad = _dbSet.Find(id);

            if (entidad != null)
            {
                _dbSet.Remove(entidad);
                _context.SaveChanges();
            }
        }
    }
}