using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoDeRestaurante.Context;

namespace ProjetoDeRestaurante.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;
        public CarrinhoCompra (AppDbContext context)
        {
            _context = context;
        }
        public string Id { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens;

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço de contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera id do carrinho 
            string carrinhoId =  session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                Id = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Pedido pedido)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(m => m.Pedido.Id == pedido.Id && m.CarrinhoCompraId == Id);
            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = Id,
                    Pedido = pedido,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverDoCarrinho(Pedido pedido)
        {
            var CarrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(m => m.Pedido.Id == pedido.Id && m.CarrinhoCompraId == Id);
            var quantidadeLocal = 0;
            if(CarrinhoCompraItem != null)
            {
                if(CarrinhoCompraItem.Quantidade > 1)
                {
                    CarrinhoCompraItem.Quantidade--;
              //    quantidadeLocal = CarrinhoCompraItem.Quantidade; //se trocar o void por Int tornasse necessário inserir o returno e quantidade local
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(CarrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            
            //return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            var ListPedidos = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == Id).ToList();
            return CarrinhoCompraItens ?? (CarrinhoCompraItens = _context.CarrinhoCompraItens
                .Where(c=>c.CarrinhoCompraId == Id)
                .Include(p=>p.Pedido)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var CarrinhoItens = _context.CarrinhoCompraItens.Where(carrinho => carrinho.CarrinhoCompraId == Id);
            _context.CarrinhoCompraItens.RemoveRange(CarrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == Id)
                        .Select(c => c.Pedido.Preco * c.Quantidade).Sum();

            return total;
        }

        
    }
}
