using System.Net.Http.Json;
using SistemaAula.Blazor.Models;

namespace SistemaAula.Blazor.Services;

public class HorarioApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HorarioApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private HttpClient ObtenerCliente()
    {
        return _httpClientFactory.CreateClient("Api");
    }

    public async Task<List<HorarioModel>> ObtenerHorariosAsync()
    {
        try
        {
            var cliente = ObtenerCliente();

            // Intenta primero con api/horario; si tu controller es HorariosController, usa "api/Horarios"
            var horarios = await cliente.GetFromJsonAsync<List<HorarioModel>>("api/horario");
            return horarios ?? new List<HorarioModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR HORARIOS]: {ex.Message}");
            return new List<HorarioModel>();
        }
    }

    public async Task<bool> CrearHorarioAsync(HorarioModel horario)
    {
        try
        {
            var cliente = ObtenerCliente();
            var response = await cliente.PostAsJsonAsync("api/horario", horario);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> EliminarHorarioAsync(int id)
    {
        try
        {
            var cliente = ObtenerCliente();
            var response = await cliente.DeleteAsync($"api/horario/{id}");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}