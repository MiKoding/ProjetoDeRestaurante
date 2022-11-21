using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pedido> LanchesPreferidos { get; set; }
    }
}
