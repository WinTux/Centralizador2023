using Centralizador2023.Models;
using Microsoft.EntityFrameworkCore;

namespace Centralizador2023.Repositorios
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions<EmpresaDbContext> opciones) : base(opciones)
        {
            
        }
        public DbSet<Programador> Programadores { get; set; }
    }
}
