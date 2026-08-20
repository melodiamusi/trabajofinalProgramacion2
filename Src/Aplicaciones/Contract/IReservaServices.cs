using SistemaAula.Aplicaciones.Dto.Reserva;

namespace SistemaAula.Aplicaciones.Contract;

public interface IReservaServices
{
    List<ReservaDto> ObtenerTodas();
    (bool Exito, string Mensaje) CrearReserva(CrearReservaDto dto);
    bool CambiarEstado(int id, string nuevoEstado);
    bool Eliminar(int id);
}