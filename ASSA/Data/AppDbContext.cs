using ASSA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASSA.Data
{
    // La clase AppDbContext hereda de DbContext, lo que permite que interactúe con la base de datos mediante Entity Framework Core.
    public class AppDbContext : DbContext
    {
        // Definición de DbSet para la tabla 'MarcasAutos', que representa el conjunto de marcas de autos en la base de datos.
        public DbSet<MarcaAuto> MarcasAutos { get; set; }

        // Constructor que recibe DbContextOptions. Estas opciones son configuradas externamente
        // lo que permite que se inyecten las configuraciones específicas para conectar a la base de datos (como la cadena de conexión).
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Método opcional que permite configurar el DbContext de forma programática.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // La cadena de conexión a PostgreSQL, se inyecta en la clase program.cs
        }

        // Método que permite personalizar el mapeo entre las clases y la base de datos cuando se crea el modelo.
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se define que la entidad MarcaAuto tendrá datos predefinidos (seeding).
            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto { Id = 1, Nombre = "Toyota" },   // Datos iniciales para la tabla MarcasAutos
                new MarcaAuto { Id = 2, Nombre = "Ford" },
                new MarcaAuto { Id = 3, Nombre = "Chevrolet" }
            );
        }
    }
}
