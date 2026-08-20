using SistemaAula.Aplicaciones.Dto.Profesor;

namespace SistemaAula.Aplicaciones.Contract;

public interface IProfesorServices
{
    List<ProfesorDto> ObtenerTodos();
    bool Crear(CrearProfesorDto dto);
    bool Actualizar(int id, CrearProfesorDto dto);
    bool Eliminar(int id);
}