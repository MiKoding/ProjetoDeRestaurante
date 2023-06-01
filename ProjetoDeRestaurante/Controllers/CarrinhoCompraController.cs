using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public ActionResult AdicionarItemNoCarrinhoCompra(int pedidoId)
        {
            var pedidoSelecionado = _pedidoRepositoy.Pedidos.FirstOrDefault(p => p.Id == pedidoId);

            if(pedidoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(pedidoSelecionado);
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        public RedirectToActionResult RemoverItemDoCarrinho(int pedidoId)
        {
            var pedidoSelecionado = _pedidoRepositoy.Pedidos.FirstOrDefault(p => p.Id == pedidoId);
            if(pedidoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(pedidoSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
