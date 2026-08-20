using Microsoft.AspNetCore.Mvc;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Curso;

namespace SistemaAula.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursoController : ControllerBase
{
    private readonly ICursoServices _service;

    public CursoController(ICursoServices service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());

    [HttpPost]
    public IActionResult Crear([FromBody] CrearCursoDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Nombre))
            return BadRequest("Datos del curso inválidos.");

        if (_service.Crear(dto)) return Ok("Curso creado correctamente.");
        return BadRequest("No se pudo crear el curso.");
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] CrearCursoDto dto)
    {
        if (_service.Actualizar(id, dto)) return Ok("Curso actualizado correctamente.");
        return NotFound("Curso no encontrado.");
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        if (_service.Eliminar(id)) return Ok("Curso eliminado correctamente.");
        return NotFound("Curso no encontrado.");
    }
}