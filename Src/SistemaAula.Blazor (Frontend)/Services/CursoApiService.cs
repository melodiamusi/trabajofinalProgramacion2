using System.Net.Http.Json;
using SistemaAula.Blazor.Models;

namespace SistemaAula.Blazor.Services;

public class CursoApiService
{
    private readonly HttpClient _http;

    public CursoApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<List<CursoModel>> ObtenerCursosAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<CursoModel>>("api/Curso") ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR OBTENER CURSOS]: {ex.Message}");
            return new();
        }
    }

    public async Task<(bool Exito, string Mensaje)> CrearCursoAsync(CursoModel curso)
    {
        try
        {
            var dto = new
            {
                Nombre = curso.Nombre,
                Profesor = curso.Profesor ?? string.Empty,
                Horario = curso.Horario ?? string.Empty,
                AulaId = curso.AulaId ?? 0
            };

            var res = await _http.PostAsJsonAsync("api/Curso", dto);
            var contenido = await res.Content.ReadAsStringAsync();

            return res.IsSuccessStatusCode
                ? (true, string.IsNullOrWhiteSpace(contenido) ? "Curso registrado exitosamente." : contenido)
                : (false, $"HTTP {(int)res.StatusCode}: {contenido}");
        }
        catch (Exception ex)
        {
            return (false, $"Error: {ex.Message}");
        }
    }

    public async Task<(bool Exito, string Mensaje)> ActualizarCursoAsync(CursoModel curso)
    {
        try
        {
            if (curso.Id <= 0)
            {
                return (false, "El ID del curso no es válido para actualizar.");
            }

            var dto = new
            {
                Nombre = curso.Nombre,
                Profesor = curso.Profesor ?? string.Empty,
                Horario = curso.Horario ?? string.Empty,
                AulaId = curso.AulaId ?? 0
            };

            var res = await _http.PutAsJsonAsync($"api/Curso/{curso.Id}", dto);
            var contenido = await res.Content.ReadAsStringAsync();

            return res.IsSuccessStatusCode
                ? (true, string.IsNullOrWhiteSpace(contenido) ? "Curso actualizado exitosamente." : contenido)
                : (false, $"HTTP {(int)res.StatusCode}: {contenido}");
        }
        catch (Exception ex)
        {
            return (false, $"Error: {ex.Message}");
        }
    }

    public async Task<bool> EliminarCursoAsync(int id)
    {
        try
        {
            var res = await _http.DeleteAsync($"api/Curso/{id}");
            return res.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}