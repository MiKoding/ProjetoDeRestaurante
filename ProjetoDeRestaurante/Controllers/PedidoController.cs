using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Models;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Pedido> pedidos;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                pedidos = _pedidoRepository.Pedidos.OrderBy(p => p.Id);
                categoriaAtual = "Todos os Pedidos";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    pedidos = _pedidoRepository.Pedidos.Where(p => p.Categoria.CategoriaNome.Equals("Normal"))
                              .OrderBy(p => p.Nome);
                }
                else if(string.Equals("Naturais",categoria, StringComparison.OrdinalIgnoreCase))
                {
                    pedidos = _pedidoRepository.Pedidos.Where(p => p.Categoria.CategoriaNome.Equals("Naturais"))
                              .OrderBy(c => c.Nome);
                }
                else
                {
                    pedidos = _pedidoRepository.Pedidos.OrderBy(p => p.Id);
                    categoriaAtual = "Todos os Pedidos";
                }
                categoriaAtual = categoria;
            }

            var pedidoListViewModel = new PedidoListViewModel
            {
                Pedido = pedidos,
                CategoriaAtual = categoriaAtual
            };

            return View(pedidoListViewModel);
        }
        public IActionResult Create()
        {
            
            return View();
        }
    }
}
