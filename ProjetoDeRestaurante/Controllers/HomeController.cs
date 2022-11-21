using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories.Interface;
using ProjetoDeRestaurante.ViewModels;
using System.Diagnostics;

namespace ProjetoDeRestaurante.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }


        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _pedidoRepository.PedidosPreferidos
            };

            
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}