using ProjetoDeRestaurante.Models;
namespace ProjetoDeRestaurante.Repositories.Interface
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> Pedidos { get; }
        IEnumerable<Pedido> PedidosPreferidos { get; }
        Pedido GetPedidoId(int PedidoId);

    }
}
