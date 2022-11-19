using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.ViewModels
{
    public class PedidoListViewModel
    {
        public IEnumerable<Pedido> Pedido { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
