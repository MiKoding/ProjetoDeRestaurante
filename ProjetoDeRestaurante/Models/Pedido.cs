
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeRestaurante.Models
{

    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="O nome do pedido deve ser informado.")]
        [Display(Name = "Nome do Pedido")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do pedido deve ser informado")]
        [Display (Name = "Descrição do pedido")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "A descrição detalhada do pedido deve ser informado")]
        [Display(Name = "Descrição detalhada do pedido")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada não pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "O preço do pedido deve ser informado.")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,99.99,ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho Imagem Normal")]
        [StringLength (200, ErrorMessage = "O {0} deve ter no mínimo {1} caracteres.")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no mínimo {1} caracteres.")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido")]
        public bool IsPedidoPreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; } 

        public int CategoriaId { get; set; }
        [NotMapped]
        public DateTime DataDeCadastro { get; set; }
        public virtual Categoria Categoria { get; set; }





    }
}
