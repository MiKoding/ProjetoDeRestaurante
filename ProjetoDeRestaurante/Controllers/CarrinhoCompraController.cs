using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories.Interface;
using ProjetoDeRestaurante.ViewModels;

namespace ProjetoDeRestaurante.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IPedidoRepository _pedidoRepositoy;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IPedidoRepository pedidoRepositoy, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepositoy = pedidoRepositoy;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
                
            };


            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _pedidoRepositoy.Pedidos.FirstOrDefault(p => p.Id == lancheId);

            if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemDoCarrinho(int lancheId)
        {
            var lancheSelecionado = _pedidoRepositoy.Pedidos.FirstOrDefault(p => p.Id == lancheId);
            if(lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
