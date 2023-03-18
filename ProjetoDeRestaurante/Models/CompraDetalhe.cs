using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeRestaurante.Models
{
    public class CompraDetalhe
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public virtual Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public virtual Compra Compra { get; set; }
        public int CompraId { get; set; }

    }
}
