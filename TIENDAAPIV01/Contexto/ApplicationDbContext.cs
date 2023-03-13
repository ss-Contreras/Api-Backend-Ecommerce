using Microsoft.EntityFrameworkCore;
using TIENDAAPIV01.Models;

namespace TIENDAAPIV01.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
        
            
        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

    }
}
