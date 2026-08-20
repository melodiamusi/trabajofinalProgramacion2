using System.Net.Http.Json;
using SistemaAula.Blazor.Models;

namespace SistemaAula.Blazor.Services;

public class AulaApiService
{
    private readonly HttpClient _http;

    public AulaApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<List<AulaModel>> ObtenerAulasAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<AulaModel>>("api/Aula") ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR OBTENER AULAS]: {ex.Message}");
            return new();
        }
    }

    public async Task<(bool Exito, string Mensaje)> CrearAulaAsync(AulaModel aula)
    {
        try
        {
            var dto = new
            {
                Nombre = aula.Nombre,
                Capacidad = aula.Capacidad
            };

            var res = await _http.PostAsJsonAsync("api/Aula", dto);
            var respuesta = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                return (true, string.IsNullOrWhiteSpace(respuesta) ? "Aula creada con éxito." : respuesta);
            }

            return (false, $"HTTP {(int)res.StatusCode} ({res.StatusCode}): {respuesta}");
        }
        catch (Exception ex)
        {
            return (false, $"Excepción de conexión: {ex.Message}");
        }
    }

    public async Task<(bool Exito, string Mensaje)> ActualizarAulaAsync(AulaModel aula)
    {
        try
        {
            var dto = new
            {
                Nombre = aula.Nombre,
                Capacidad = aula.Capacidad
            };

            var res = await _http.PutAsJsonAsync($"api/Aula/{aula.Id}", dto);
            var respuesta = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                return (true, string.IsNullOrWhiteSpace(respuesta) ? "Aula actualizada." : respuesta);
            }

            return (false, $"HTTP {(int)res.StatusCode} ({res.StatusCode}): {respuesta}");
        }
        catch (Exception ex)
        {
            return (false, $"Excepción de conexión: {ex.Message}");
        }
    }

    public async Task<bool> EliminarAulaAsync(int id)
    {
        try
        {
            var res = await _http.DeleteAsync($"api/Aula/{id}");
            return res.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}