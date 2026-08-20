using System.Net.Http.Json;
using SistemaAula.Blazor.Models;

namespace SistemaAula.Blazor.Services;

public class ProfesorApiService
{
    private readonly HttpClient _http;

    public ProfesorApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<List<ProfesorModel>> ObtenerProfesores()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<ProfesorModel>>("api/Profesor") ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR OBTENER PROFESORES]: {ex.Message}");
            return new();
        }
    }

    public async Task<(bool Exito, string Mensaje)> CrearProfesorAsync(ProfesorModel profesor)
    {
        try
        {
            var dto = new
            {
                Nombre = profesor.Nombre,
                Correo = profesor.Correo ?? string.Empty,
                Especialidad = profesor.Especialidad ?? string.Empty
            };

            var res = await _http.PostAsJsonAsync("api/Profesor", dto);
            var contenido = await res.Content.ReadAsStringAsync();

            return res.IsSuccessStatusCode
                ? (true, string.IsNullOrWhiteSpace(contenido) ? "Profesor registrado exitosamente." : contenido)
                : (false, $"HTTP {(int)res.StatusCode}: {contenido}");
        }
        catch (Exception ex)
        {
            return (false, $"Error: {ex.Message}");
        }
    }

    public async Task<(bool Exito, string Mensaje)> ActualizarProfesorAsync(ProfesorModel profesor)
    {
        try
        {
            if (profesor.Id <= 0) return (false, "ID no válido para actualizar.");

            var dto = new
            {
                Nombre = profesor.Nombre,
                Correo = profesor.Correo ?? string.Empty,
                Especialidad = profesor.Especialidad ?? string.Empty
            };

            var res = await _http.PutAsJsonAsync($"api/Profesor/{profesor.Id}", dto);
            var contenido = await res.Content.ReadAsStringAsync();

            return res.IsSuccessStatusCode
                ? (true, string.IsNullOrWhiteSpace(contenido) ? "Profesor actualizado exitosamente." : contenido)
                : (false, $"HTTP {(int)res.StatusCode}: {contenido}");
        }
        catch (Exception ex)
        {
            return (false, $"Error: {ex.Message}");
        }
    }

    public async Task<bool> EliminarProfesorAsync(int id)
    {
        try
        {
            var res = await _http.DeleteAsync($"api/Profesor/{id}");
            return res.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}