using SistemaAula.Aplicaciones.Dto.Aula;

namespace SistemaAula.Aplicaciones.Contract;

public interface IAulaServices
{
    List<AulaDto> ObtenerTodos();
    bool Crear(CrearAulaDto dto);
    bool Actualizar(int id, CrearAulaDto dto);
    bool Eliminar(int id);
}