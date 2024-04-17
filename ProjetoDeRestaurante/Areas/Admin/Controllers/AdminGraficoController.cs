using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Areas.Admin.Services;

namespace ProjetoDeRestaurante.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendas;

        public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasPedidos(int dias)
        {
            var pedidosPedidosTotais = _graficoVendas.GetVendasPedidos(dias);
            return Json(pedidosPedidosTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }   
        
        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        } 
        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
