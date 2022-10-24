using ProjetoDeRestaurante.Context;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories.Interface;

namespace ProjetoDeRestaurante.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
