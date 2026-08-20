using Microsoft.AspNetCore.Mvc;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Horario;

namespace SistemaAula.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HorarioController : ControllerBase
{
    private readonly IHorarioServices _service;
    public HorarioController(IHorarioServices service) => _service = service;

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());

    [HttpPost]
    public IActionResult Crear([FromBody] CrearHorarioDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.DiaSemana))
            return BadRequest("Datos de horario inválidos.");

        return _service.Crear(dto) ? Ok("Horario registrado.") : BadRequest("Error al crear horario.");
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id) =>
        _service.Eliminar(id) ? Ok("Horario eliminado.") : NotFound("Horario no encontrado.");
}