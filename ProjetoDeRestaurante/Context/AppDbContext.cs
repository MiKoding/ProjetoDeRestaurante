using Microsoft.EntityFrameworkCore;
using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
