using Microsoft.EntityFrameworkCore;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Reserva;
using SistemaAula.Domain.Entidades;
using SistemaAula.Infrastructure.Contexto;

namespace SistemaAula.Aplicaciones.Services;

public class ReservaServices : IReservaServices
{
    private readonly ApplicationDbContext _context;

    public ReservaServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ReservaDto> ObtenerTodas()
    {
        try
        {
            return _context.Reservas
                .AsNoTracking()
                .Include(r => r.Aula)
                .Include(r => r.Horario)
                .Select(r => new ReservaDto
                {
                    Id = r.Id,
                    AulaId = r.AulaId,
                    AulaNombre = r.Aula != null ? r.Aula.Nombre : "Sin Aula",
                    HorarioId = r.HorarioId,
                    HorarioDetalle = r.Horario != null
                        ? $"{r.Horario.DiaSemana} ({r.Horario.HoraInicio:hh\\:mm} - {r.Horario.HoraFin:hh\\:mm})"
                        : "Sin Horario",
                    FechaReserva = r.FechaReserva,
                    Motivo = r.Motivo ?? string.Empty,
                    Estado = r.Estado ?? "Pendiente"
                })
                .ToList();
        }
        catch
        {
            return new List<ReservaDto>();
        }
    }

    public (bool Exito, string Mensaje) CrearReserva(CrearReservaDto dto)
    {
        if (dto == null)
        {
            return (false, "Los datos de la reserva son obligatorios.");
        }

        if (dto.ProfesorId <= 0)
        {
            return (false, "Debes seleccionar un profesor válido para la reserva.");
        }

        try
        {
            // Validar que el aula no esté ocupada en la misma fecha y horario
            bool aulaOcupada = _context.Reservas.Any(r =>
                r.AulaId == dto.AulaId &&
                r.HorarioId == dto.HorarioId &&
                r.FechaReserva.Date == dto.FechaReserva.Date &&
                r.Estado != "Rechazada");

            if (aulaOcupada)
            {
                return (false, "Conflicto: El aula seleccionada ya cuenta con una reserva activa en ese horario y fecha.");
            }

            var reserva = new Reserva
            {
                AulaId = dto.AulaId,
                HorarioId = dto.HorarioId,
                ProfesorId = dto.ProfesorId,
                FechaReserva = dto.FechaReserva.Date,
                Motivo = dto.Motivo ?? string.Empty,
                Estado = "Pendiente"
            };

            _context.Reservas.Add(reserva);
            bool guardado = _context.SaveChanges() > 0;

            return (
                guardado,
                guardado ? "Solicitud de reserva registrada exitosamente." : "Error al procesar la reserva."
            );
        }
        catch (DbUpdateException dbEx)
        {
            var detalleError = dbEx.InnerException != null ? dbEx.InnerException.Message : dbEx.Message;
            return (false, $"Error de Base de Datos: {detalleError}");
        }
        catch (Exception ex)
        {
            return (false, $"Error interno al registrar reserva: {ex.Message}");
        }
    }

    public bool CambiarEstado(int id, string nuevoEstado)
    {
        try
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null) return false;

            reserva.Estado = nuevoEstado;
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
            var reserva = _context.Reservas.Find(id);
            if (reserva == null) return false;

            _context.Reservas.Remove(reserva);
            return _context.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}