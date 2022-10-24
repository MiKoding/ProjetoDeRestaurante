using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.Repositories.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
