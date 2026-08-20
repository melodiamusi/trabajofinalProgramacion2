using Microsoft.EntityFrameworkCore;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Curso;
using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Aplicaciones.Services;

public class CursoServices : ICursoServices
{
    private readonly ApplicationDbContext _context;

    public CursoServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<CursoDto> ObtenerTodos()
    {
        try
        {
            return _context.Cursos
                .AsNoTracking()
                .Select(c => new CursoDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Profesor = c.Profesor,
                    Horario = c.Horario,
                    AulaId = c.AulaId
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR OBTENER CURSOS]: {ex.Message}");
            return new List<CursoDto>();
        }
    }

    public bool Crear(CrearCursoDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Nombre)) return false;

        try
        {
            var curso = new Curso
            {
                Nombre = dto.Nombre.Trim(),
                Profesor = (dto.Profesor ?? string.Empty).Trim(),
                Horario = (dto.Horario ?? string.Empty).Trim(),
                AulaId = dto.AulaId
            };

            _context.Cursos.Add(curso);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR CREAR CURSO]: {ex.Message}");
            return false;
        }
    }

    public bool Actualizar(int id, CrearCursoDto dto)
    {
        if (dto == null || id <= 0) return false;

        try
        {
            var cursoExistente = _context.Cursos.FirstOrDefault(c => c.Id == id);
            if (cursoExistente == null) return false;

            cursoExistente.Nombre = dto.Nombre.Trim();
            cursoExistente.Profesor = (dto.Profesor ?? string.Empty).Trim();
            cursoExistente.Horario = (dto.Horario ?? string.Empty).Trim();
            cursoExistente.AulaId = dto.AulaId;

            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR ACTUALIZAR CURSO]: {ex.Message}");
            return false;
        }
    }

    public bool Eliminar(int id)
    {
        try
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);
            if (curso == null) return false;

            _context.Cursos.Remove(curso);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR ELIMINAR CURSO]: {ex.Message}");
            return false;
        }
    }
}