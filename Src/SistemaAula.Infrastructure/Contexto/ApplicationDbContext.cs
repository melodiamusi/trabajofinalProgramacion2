using Microsoft.EntityFrameworkCore;
using SistemaAula.Domain.Entidades;

namespace SistemaAula.Infrastructure.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo explícito a los nombres de tus tablas en SQL Server
            modelBuilder.Entity<Profesor>().ToTable("Profesor");
            modelBuilder.Entity<Aula>().ToTable("Aula");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante");

            // Si creaste Horario o Horarios / Reserva o Reservas, especifícalos:
            modelBuilder.Entity<Horario>().ToTable("Horarios");
            modelBuilder.Entity<Reserva>().ToTable("Reservas");
        }
    }
}