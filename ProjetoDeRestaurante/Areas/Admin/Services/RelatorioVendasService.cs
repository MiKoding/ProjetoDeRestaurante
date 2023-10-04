using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDeRestaurante.Context;
using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.Areas.Admin.Services
{
    public class RelatorioVendasService 
    {
        private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Compra>> FindByDateAssync(DateTime? minDate, DateTime? maxDate){// executa a busca de compras de uma data minima e maxima
        
            var resultado =  from obj in context.Compras select obj;

            if (minDate.HasValue){
                resultado = resultado.Where(x => x.CompraEnviada >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.CompraEnviada <= maxDate.Value); 

            }
            return await resultado.Include(l => l.CompraItens)
                .ThenInclude(l => l.Pedido)
                .OrderByDescending(x => x.CompraEnviada)
                .ToListAsync();
        }
    }
}
