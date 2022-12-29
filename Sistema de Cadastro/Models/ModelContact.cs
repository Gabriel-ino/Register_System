using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Cadastro.Models
{
    public class ModelContact
    {
  
        public int Id { get; set; }

        [Required(ErrorMessage = "Type contact's name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Type contact's email")]

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage="Type contact's phone")]
        [Phone(ErrorMessage = "Phone is invalid")]
        public string? Contact { get; set; }



    }
}
