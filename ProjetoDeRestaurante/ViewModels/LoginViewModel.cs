using System.ComponentModel.DataAnnotations;

namespace ProjetoDeRestaurante.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o usuário")]
        [Display(Name ="Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        public string Pàssword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
