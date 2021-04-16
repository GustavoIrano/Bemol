using System.ComponentModel.DataAnnotations;

namespace bemol.App.Models
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} não pode ter mais de 200 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} não pode ter mais de 200 caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} não pode ter mais de 200 caracteres!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} não pode ter mais de 200 caracteres!")]
        public string Cpf { get; set; }

        public AddressViewModel AddressViewModel { get; set; }
    }
}
