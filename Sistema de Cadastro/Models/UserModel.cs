using Sistema_de_Cadastro.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Cadastro.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please type a valid email")]
        public string Email { get; set; }

        public ProfileEnum profile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set;}
    }
}
