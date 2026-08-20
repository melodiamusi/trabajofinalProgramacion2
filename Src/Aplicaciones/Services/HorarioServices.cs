using Microsoft.EntityFrameworkCore;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Horario;
using SistemaAula.Domain.Entidades; // <-- Fundamental para reconocer Horario
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Aplicaciones.Services;

public class HorarioServices : IHorarioServices
{
    private readonly ApplicationDbContext _context;

    public HorarioServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<HorarioDto> ObtenerTodos()
    {
        try
        {
            return _context.Horarios
                .AsNoTracking()
                .AsEnumerable()
                .Select(h => new HorarioDto
                {
                    Id = h.Id,
                    DiaSemana = h.DiaSemana ?? string.Empty,
                    HoraInicio = h.HoraInicio,
                    HoraFin = h.HoraFin
                })
                .ToList();
        }
        catch
        {
            return new List<HorarioDto>();
        }
    }

    public bool Crear(CrearHorarioDto dto)
    {
        if (dto == null) return false;

        try
        {
            var horario = new Horario
            {
                DiaSemana = dto.DiaSemana ?? string.Empty,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin
            };

            _context.Horarios.Add(horario);
            return _context.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool Eliminar(int id)
    {
        try
        {
            var horario = _context.Horarios.Find(id);
            if (horario == null) return false;

            // Evitar eliminar si ya está en una reserva
            bool enUso = _context.Reservas.Any(r => r.HorarioId == id);
            if (enUso) return false;

            _context.Horarios.Remove(horario);
            return _context.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}