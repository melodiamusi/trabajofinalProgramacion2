using Microsoft.AspNetCore.Mvc;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Dto.Profesor;

namespace SistemaAula.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfesorController : ControllerBase
{
    private readonly IProfesorServices _service;

    public ProfesorController(IProfesorServices service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CrearProfesorDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Nombre))
        {
            return BadRequest("El nombre del profesor es requerido.");
        }

        try
        {
            bool creado = _service.Crear(dto);

            if (!creado)
            {
                return BadRequest(
                    "No se pudo insertar el registro en la base de datos."
                );
            }

            return Ok("Profesor registrado exitosamente.");
        }
        catch (Exception ex)
        {
            var mensajeDetalle =
                ex.InnerException != null
                    ? ex.InnerException.Message
                    : ex.Message;

            return BadRequest(
                $"Error de Base de Datos: {mensajeDetalle}"
            );
        }
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(
        int id,
        [FromBody] CrearProfesorDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Nombre))
        {
            return BadRequest("El nombre del profesor es requerido.");
        }

        return _service.Actualizar(id, dto)
            ? Ok("Profesor actualizado.")
            : NotFound("Profesor no encontrado.");
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        return _service.Eliminar(id)
            ? Ok("Profesor eliminado.")
            : NotFound("Profesor no encontrado.");
    }
}