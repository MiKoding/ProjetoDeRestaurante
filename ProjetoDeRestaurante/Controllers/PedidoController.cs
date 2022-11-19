using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Repositories.Interface;
using ProjetoDeRestaurante.ViewModels;

namespace ProjetoDeRestaurante.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult List()
        {
            ViewData["Titulo"] = "Todos os pedidos";
            ViewData["Data"] = DateTime.Now;
            var pedidos = _pedidoRepository.Pedidos;
            var TotalLanches = pedidos.Count();
            ViewBag.Total = "Total de Lanches:";
            ViewBag.TotalLanches = TotalLanches;
            //return View(pedidos);
            var pedidoListViewModel = new PedidoListViewModel();
            pedidoListViewModel.Pedido = _pedidoRepository.Pedidos;
            pedidoListViewModel.CategoriaAtual = "Categoria Atual";
            return View(pedidoListViewModel);
        }
        public IActionResult Create()
        {
            
            return View();
        }
    }
}
