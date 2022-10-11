
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeRestaurante.Models
{

    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="O nome do pedido deve ser informado")]
        [Display(Name = "Nome do Pedido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do pedido deve ser informado")]
        [Display (Name = "Descrição do pedido")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }  
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsPedidoPreferido { get; set; }
        public bool EmEstoque { get; set; } 

        public int CategoriaId { get; set; }
        [NotMapped]
        public DateTime DataDeCadastro { get; set; }
        public virtual Categoria Categoria { get; set; }





    }
}
