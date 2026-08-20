using Microsoft.AspNetCore.Mvc;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Reserva;

namespace SistemaAula.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservaController : ControllerBase
{
    private readonly IReservaServices _service;

    public ReservaController(IReservaServices service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        return Ok(_service.ObtenerTodas());
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CrearReservaDto dto)
    {
        var (exito, mensaje) = _service.CrearReserva(dto);
        if (exito)
        {
            return Ok(mensaje);
        }
        return BadRequest(mensaje);
    }

    [HttpPut("{id}/estado")]
    public IActionResult CambiarEstado(int id, [FromBody] string nuevoEstado)
    {
        if (_service.CambiarEstado(id, nuevoEstado))
        {
            return Ok("Estado actualizado correctamente.");
        }
        return BadRequest("No se pudo cambiar el estado de la reserva.");
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        if (_service.Eliminar(id))
        {
            return Ok("Reserva eliminada correctamente.");
        }
        return NotFound("No se encontró la reserva.");
    }
}