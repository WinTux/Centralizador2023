using Centralizador2023.Models;
using Microsoft.EntityFrameworkCore;

namespace Centralizador2023.Repositorios
{
    public class InstitutoXDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public InstitutoXDbContext(DbContextOptions<InstitutoXDbContext> opciones) : base(opciones)
        {

        }
        
    }
}
