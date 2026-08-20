using Microsoft.EntityFrameworkCore;
using SistemaAula.Aplicaciones.Contract;
using SistemaAula.Aplicaciones.Services;
using SistemaAula.Infrastructure.Contexto;
using SistemaAula.Infrastructure.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Configuración de CORS (Comunicación distribuida para Blazor, JS, etc.)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Inyección de Dependencias: Servicios Base
builder.Services.AddScoped<IEstudianteServices, EstudianteServicio>();
builder.Services.AddScoped<IAulaServices, AulaServices>();
builder.Services.AddScoped<ICursoServices, CursoServices>();

// Inyección de Dependencias: Nuevos Módulos (Profesores, Horarios, Reservas)
builder.Services.AddScoped<IProfesorServices, ProfesorServices>();
builder.Services.AddScoped<IHorarioServices, HorarioServices>();
builder.Services.AddScoped<IReservaServices, ReservaServices>();

// Inyección de Dependencias: Repositorios
builder.Services.AddScoped<EstudianteRepositorio, EstudianteRepositorio>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS en el pipeline (antes de MapControllers)
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();