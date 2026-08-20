using Microsoft.AspNetCore.Mvc;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Aula;

namespace SistemaAula.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AulaController : ControllerBase
{
    private readonly IAulaServices _service;

    public AulaController(IAulaServices service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());

    [HttpPost]
    public IActionResult Crear([FromBody] CrearAulaDto dto)
    {
        if (_service.Crear(dto)) return Ok("Aula creada correctamente.");
        return BadRequest("No se pudo crear el aula.");
    }

    // <-- ESTE MÉTODO ES EL QUE FALTA PARA EDITAR/ACTUALIZAR
    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] CrearAulaDto dto)
    {
        if (_service.Actualizar(id, dto))
        {
            return Ok("Aula actualizada correctamente.");
        }
        return NotFound("No se encontró el aula con el ID especificado.");
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        if (_service.Eliminar(id)) return Ok("Aula eliminada correctamente.");
        return NotFound("Aula no encontrada.");
    }
}