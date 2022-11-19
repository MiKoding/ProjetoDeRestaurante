using System.ComponentModel.DataAnnotations;


namespace ProjetoDeRestaurante.Models
{
    public class CarrinhoCompraItem
    {
        public int Id { get; set; } 
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
