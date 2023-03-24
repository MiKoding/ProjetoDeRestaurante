using ProjetoDeRestaurante.Context;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories.Interface;

namespace ProjetoDeRestaurante.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CompraRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Compra compra)
        {
            compra.CompraEnviada = DateTime.Now;
            _appDbContext.Compras.Add(compra);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new CompraDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    CompraId = compra.Id,
                    PedidoId = carrinhoItem.Pedido.Id,
                    Preco = carrinhoItem.Pedido.Preco
                };

                _appDbContext.CompraDetalhes.Add(pedidoDetail);
            };

            _appDbContext.SaveChanges();
        }
    }
}
