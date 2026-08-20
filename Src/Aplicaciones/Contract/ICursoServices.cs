using SistemaAula.Aplicaciones.Dto.Curso;

namespace SistemaAula.Aplicaciones.Contract;

public interface ICursoServices
{
    List<CursoDto> ObtenerTodos();
    bool Crear(CrearCursoDto dto);
    bool Actualizar(int id, CrearCursoDto dto);
    bool Eliminar(int id);
}