using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoDeRestaurante.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) { 
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
