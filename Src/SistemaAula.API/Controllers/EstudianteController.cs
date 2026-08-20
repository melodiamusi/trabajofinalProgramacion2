using Microsoft.AspNetCore.Mvc;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Estudiante;

namespace SistemaAula.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudianteController : ControllerBase
{
    private readonly IEstudianteServices _service;

    public EstudianteController(IEstudianteServices service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());

    [HttpPost]
    public IActionResult Crear([FromBody] CrearEstudianteDto dto)
    {
        if (dto == null) return BadRequest("Los datos del estudiante son nulos.");
        if (_service.Crear(dto)) return Ok("Estudiante creado correctamente.");
        return BadRequest("No se pudo insertar el estudiante.");
    }

    // <-- ESTE MÉTODO ES EL QUE FALTA PARA EDITAR/ACTUALIZAR
    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] CrearEstudianteDto dto)
    {
        if (_service.Actualizar(id, dto))
        {
            return Ok("Estudiante actualizado correctamente.");
        }
        return NotFound("No se encontró el estudiante con el ID especificado.");
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        if (_service.Eliminar(id)) return Ok("Estudiante eliminado.");
        return NotFound();
    }
}