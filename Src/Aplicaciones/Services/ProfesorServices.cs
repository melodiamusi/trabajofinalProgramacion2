using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Profesor;
using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Aplicaciones.Services;

public class ProfesorServices : IProfesorServices
{
    private readonly ApplicationDbContext _context;

    public ProfesorServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ProfesorDto> ObtenerTodos()
    {
        try
        {
            return _context.Profesores
                .AsNoTracking()
                .Select(p => new ProfesorDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre ?? string.Empty,
                    Correo = p.Correo ?? string.Empty,
                    Especialidad = p.Especialidad ?? string.Empty
                })
                .ToList();
        }
        catch
        {
            return new List<ProfesorDto>();
        }
    }

    public bool Crear(CrearProfesorDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Nombre))
            return false;

        try
        {
            var nuevoProfesor = new Profesor
            {
                Nombre = dto.Nombre.Trim(),
                Correo = (dto.Correo ?? string.Empty).Trim(),
                Especialidad = (dto.Especialidad ?? string.Empty).Trim()
            };

            _context.Profesores.Add(nuevoProfesor);
            return _context.SaveChanges() > 0;
        }
        catch
        {
            throw; // Permite que el Controller capture el mensaje exacto si la base de datos rechaza la inserción
        }
    }

    public bool Actualizar(int id, CrearProfesorDto dto)
    {
        if (dto == null || id <= 0) return false;

        try
        {
            var profesor = _context.Profesores.FirstOrDefault(p => p.Id == id);
            if (profesor == null) return false;

            profesor.Nombre = dto.Nombre.Trim();
            profesor.Correo = (dto.Correo ?? string.Empty).Trim();
            profesor.Especialidad = (dto.Especialidad ?? string.Empty).Trim();

            return _context.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool Eliminar(int id)
    {
        if (id <= 0) return false;

        try
        {
            var profesor = _context.Profesores.FirstOrDefault(p => p.Id == id);
            if (profesor == null) return false;

            _context.Profesores.Remove(profesor);
            return _context.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}