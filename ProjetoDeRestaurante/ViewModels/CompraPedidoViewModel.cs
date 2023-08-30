using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.ViewModels
{
    public class CompraPedidoViewModel
    {
        public Compra Compra {  get; set; } 
        public IEnumerable<CompraDetalhe> CompraDetalhes { get; set;}

    }
}
