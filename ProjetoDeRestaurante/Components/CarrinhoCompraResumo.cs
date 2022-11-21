using Microsoft.AspNetCore.Mvc;
using ProjetoDeRestaurante.Models;
using ProjetoDeRestaurante.ViewModels;

namespace ProjetoDeRestaurante.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }



        public IViewComponentResult Invoke()
        {
            //var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            var itens = new List<CarrinhoCompraItem>(){
                    new CarrinhoCompraItem(),
                    new CarrinhoCompraItem(),

            }; // teste de quantidade
            _carrinhoCompra.CarrinhoCompraItens = itens;
            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()

            };


            return View(carrinhoCompraVM);
        }
    }
}
