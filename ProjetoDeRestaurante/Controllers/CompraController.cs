using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories.Interface;

namespace ProjetoDeRestaurante.Controllers
{
    public class CompraController : Controller
    {
        private readonly ICompraRepository _compraRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CompraController(ICompraRepository compraRepository, CarrinhoCompra carrinhoCompra)
        {
            _compraRepository = compraRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Compra compra)
        {
            int totalItensCompra = 0;
            decimal precoTotal = 0.0m;

            //obtem itens do carrinho compra itens
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;

            //verifica existencia de itens
            if(_carrinhoCompra.CarrinhoCompraItens.Count() == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir um pedido...");
            }

            //calcular o total de itens e total do pedido
            foreach (var item in items)
            {
                totalItensCompra += item.Quantidade;
                precoTotal += item.Pedido.Preco * item.Quantidade;
            }

            //atribui valores obtidos
            compra.TotalItensCompra = totalItensCompra;
            compra.CompraTotal = precoTotal;

            if (ModelState.IsValid)
            {
                //cria a compra e os detalhes
                _compraRepository.CriarPedido(compra);
                //mensagens ao cliente
                ViewBag.CheckouCompletoMensagem = "Agradecemos a sua preferência :)";
                ViewBag.TotalCompra = _carrinhoCompra.GetCarrinhoCompraTotal();

                //limpa o carrinho do cliente
                _carrinhoCompra.LimparCarrinho();

                return View("~/Views/Compra/CheckoutCompleto.cshtml", compra);

            }

            return View(compra);
        }
    }
}
