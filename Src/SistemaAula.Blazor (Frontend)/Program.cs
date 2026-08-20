using SistemaAula.Blazor.Services;
// Revisa si tu App.razor está en este namespace o simplemente usa el que generó tu proyecto:
using SistemaAula.Blazor__Frontend_.Components;

var builder = WebApplication.CreateBuilder(args);

// Modo interactivo de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configuración del HttpClient con el puerto real de la API
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:44388/");
    client.Timeout = TimeSpan.FromSeconds(10);
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
});

// Asignar el HttpClient por defecto
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

// Inyección de dependencias de servicios
builder.Services.AddScoped<AulaApiService>();
builder.Services.AddScoped<EstudianteApiService>();
builder.Services.AddScoped<CursoApiService>();
builder.Services.AddScoped<ProfesorApiService>();
builder.Services.AddScoped<HorarioApiService>();
builder.Services.AddScoped<ReservaApiService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();