using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Aula;
using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Aplicaciones.Services;

public class AulaServices : IAulaServices
{
    private readonly ApplicationDbContext _context;

    public AulaServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<AulaDto> ObtenerTodos()
    {
        return _context.Aulas
            .Select(a => new AulaDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Capacidad = a.Capacidad
            })
            .ToList();
    }

    public bool Crear(CrearAulaDto dto)
    {
        if (dto == null)
            return false;

        if (string.IsNullOrWhiteSpace(dto.Nombre))
            return false;

        if (dto.Capacidad <= 0)
            return false;

        var nueva = new Aula
        {
            Nombre = dto.Nombre,
            Capacidad = dto.Capacidad
        };

        _context.Aulas.Add(nueva);

        return _context.SaveChanges() > 0;
    }

    public bool Actualizar(int id, CrearAulaDto dto)
    {
        if (dto == null)
            return false;

        var aula = _context.Aulas.Find(id);

        if (aula == null)
            return false;

        if (string.IsNullOrWhiteSpace(dto.Nombre))
            return false;

        if (dto.Capacidad <= 0)
            return false;

        aula.Nombre = dto.Nombre;
        aula.Capacidad = dto.Capacidad;

        return _context.SaveChanges() > 0;
    }

    public bool Eliminar(int id)
    {
        var aula = _context.Aulas.Find(id);

        if (aula == null)
            return false;

        _context.Aulas.Remove(aula);

        return _context.SaveChanges() > 0;
    }
}