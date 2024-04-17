using ProjetoDeRestaurante.Context;
using ProjetoDeRestaurante.Models;

namespace ProjetoDeRestaurante.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext context;
        public GraficoVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public List<PedidoGrafico> GetVendasPedidos(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias); //define os dias de varredura para a listagem de pedidos abaixo
            var pedidos = (from pd in context.CompraDetalhes
                           join l in context.Pedidos on pd.PedidoId equals l.Id
                           where pd.Compra.CompraEnviada >= data
                           group pd by new { pd.PedidoId, l.Nome }
                           into g
                           select new
                           {
                               PedidoNome = g.Key.Nome,
                               PedidoQuantidade = g.Sum(q => q.Quantidade),
                               PedidoValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           }); //varredura e instancia do banco de dados dos pedidos de acordo com o periodo, através de inner join da tabela Pedidos e CompraDetalhes

           
            var lista = new List<PedidoGrafico>();
            foreach(var item in pedidos)
            {
                var pedido = new PedidoGrafico();
                pedido.PedidoNome = item.PedidoNome;
                pedido.PedidosQuantidade = item.PedidoQuantidade;
                pedido.PedidosValorTotal = item.PedidoValorTotal;
                lista.Add(pedido);
            } //Instancia os valores de pedidos na tabela PedidoGrafico

            return lista;
        }
    }
}
