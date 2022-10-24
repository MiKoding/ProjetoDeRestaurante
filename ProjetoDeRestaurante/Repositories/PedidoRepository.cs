using Microsoft.EntityFrameworkCore;
using ProjetoDeRestaurante.Context;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.Repositories.Interface;

namespace ProjetoDeRestaurante.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        public PedidoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Pedido> Pedidos => _context.Pedidos.Include(c => c.Categoria);
        public IEnumerable<Pedido> PedidosPreferidos => _context.Pedidos
            .Where(p => p.IsPedidoPreferido)
            .Include(p => p.Categoria);   

        public Pedido GetPedidoId(int PedidoId)
        {
            return _context.Pedidos.FirstOrDefault(p => p.Id == PedidoId);
        }
    }
}
