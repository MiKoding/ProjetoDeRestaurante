using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoDeRestaurante.Areas.Admin.Controllers
{
    [Authorize("Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
