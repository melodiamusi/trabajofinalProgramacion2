using System.Net.Http.Json;
using SistemaAula.Blazor.Models;

namespace SistemaAula.Blazor.Services;

public class EstudianteApiService
{
    private readonly HttpClient _http;

    public EstudianteApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("SistemaAulaAPI");
    }

    public async Task<List<EstudianteModel>> ObtenerEstudiantesAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<EstudianteModel>>("api/Estudiante") ?? new();
        }
        catch
        {
            return new();
        }
    }

    public async Task<bool> CrearEstudianteAsync(EstudianteModel estudiante)
    {
        try
        {
            var dto = new
            {
                nombre = estudiante.Nombre,
                apellido = estudiante.Apellido,
                matricula = estudiante.Matricula,
                email = estudiante.Email
            };

            var res = await _http.PostAsJsonAsync("api/Estudiante", dto);
            return res.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    // <-- Método para actualizar que faltaba
    public async Task<bool> ActualizarEstudianteAsync(EstudianteModel estudiante)
    {
        try
        {
            var dto = new
            {
                nombre = estudiante.Nombre,
                apellido = estudiante.Apellido,
                matricula = estudiante.Matricula,
                email = estudiante.Email
            };

            var res = await _http.PutAsJsonAsync($"api/Estudiante/{estudiante.Id}", dto);
            return res.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> EliminarEstudianteAsync(int id)
    {
        try
        {
            var res = await _http.DeleteAsync($"api/Estudiante/{id}");
            return res.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}