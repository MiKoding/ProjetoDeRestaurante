using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.Repositories.Interface
{
    public interface ICompraRepository
    {
        void CriarPedido(Compra compra);
    }
}
