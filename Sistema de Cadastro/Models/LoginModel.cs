using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Cadastro.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Type login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Type Password")]
        public string Password { get; set; }
    }
}
