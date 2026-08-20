using System.Net.Http.Json;
using SistemaAula.Blazor.Models;

namespace SistemaAula.Blazor.Services;

public class ReservaApiService
{
    private readonly HttpClient _http;
    public ReservaApiService(HttpClient http) => _http = http;

    public async Task<List<ReservaModel>> ObtenerReservasAsync() =>
        await _http.GetFromJsonAsync<List<ReservaModel>>("api/reserva") ?? new();

    public async Task<(bool Exito, string Mensaje)> CrearReservaAsync(ReservaModel reserva)
    {
        var response = await _http.PostAsJsonAsync("api/reserva", reserva);
        var msg = await response.Content.ReadAsStringAsync();
        return (response.IsSuccessStatusCode, msg);
    }

    public async Task<bool> CambiarEstadoAsync(int id, string nuevoEstado)
    {
        // Se usa PutAsJsonAsync en lugar de HttpPutAsync
        var response = await _http.PutAsJsonAsync($"api/reserva/{id}/estado", nuevoEstado);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EliminarReservaAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/reserva/{id}");
        return response.IsSuccessStatusCode;
    }
}