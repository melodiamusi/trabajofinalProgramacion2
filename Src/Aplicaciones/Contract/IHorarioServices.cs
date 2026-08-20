using SistemaAula.Aplicaciones.Dto.Horario;

namespace SistemaAula.Aplicaciones.Contract;

public interface IHorarioServices
{
    List<HorarioDto> ObtenerTodos();
    bool Crear(CrearHorarioDto dto);
    bool Eliminar(int id);
}