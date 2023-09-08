using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeRestaurante.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "informe o seu nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "informe o seu sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "informe o seu endereço")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Insira seu CEP")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "o email não possui um formato correto")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName="decimal(18,2)")]
        [Display(Name ="Total da Compra")]
        public decimal CompraTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name ="Itens na compra")]
        public int TotalItensCompra { get; set; }

        [Display(Name ="Data do pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CompraEnviada { get; set; }

        [Display(Name = "Data da entrega")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CompraEntregaEm { get; set; }

        public List<CompraDetalhe> CompraItens { get; set; }//definiu uma relação entre pedido e compras


    }
}
