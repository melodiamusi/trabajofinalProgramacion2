using Microsoft.EntityFrameworkCore;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Estudiante;
using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Aplicaciones.Services;

public class EstudianteServicio : IEstudianteServices
{
    private readonly ApplicationDbContext _context;

    public EstudianteServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<EstudianteDto> ObtenerTodos()
    {
        return _context.Estudiantes.Select(e => new EstudianteDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Matricula = e.Matricula,
            Email = e.Email
        }).ToList();
    }

    public bool Crear(CrearEstudianteDto dto)
    {
        var nuevo = new Estudiante
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Matricula = dto.Matricula,
            Email = dto.Email
        };

        _context.Estudiantes.Add(nuevo);
        return _context.SaveChanges() > 0;
    }

    public bool Actualizar(int id, CrearEstudianteDto dto)
    {
        var estudiante = _context.Estudiantes.Find(id);
        if (estudiante == null) return false;

        estudiante.Nombre = dto.Nombre;
        estudiante.Apellido = dto.Apellido;
        estudiante.Matricula = dto.Matricula;
        estudiante.Email = dto.Email;

        return _context.SaveChanges() > 0;
    }

    public bool Eliminar(int id)
    {
        var estudiante = _context.Estudiantes.Find(id);
        if (estudiante == null) return false;

        _context.Estudiantes.Remove(estudiante);
        return _context.SaveChanges() > 0;
    }
}