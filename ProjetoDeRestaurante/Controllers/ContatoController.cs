using Microsoft.AspNetCore.Mvc;

namespace ProjetoDeRestaurante.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
