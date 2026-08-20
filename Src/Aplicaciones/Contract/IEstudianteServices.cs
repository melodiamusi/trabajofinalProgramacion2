using SistemaAula.Aplicaciones.Dto.Estudiante;

namespace SistemaAula.Aplicaciones.Contract;

public interface IEstudianteServices
{
    List<EstudianteDto> ObtenerTodos();
    bool Crear(CrearEstudianteDto dto);
    bool Actualizar(int id, CrearEstudianteDto dto);
    bool Eliminar(int id);
}