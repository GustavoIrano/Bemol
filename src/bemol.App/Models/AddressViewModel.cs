using System.ComponentModel.DataAnnotations;

namespace bemol.App.Models
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(200, ErrorMessage = "O campo {0} não pode ter mais de 200 caracteres!")]
        public string Street { get; set; }

        [StringLength(150, ErrorMessage = "O campo {0} não pode ter mais de 150 caracteres!")]
        public string Complement { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(9, ErrorMessage = "O campo {0} não foi preenchido corretamente!", MinimumLength = 9)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(150, ErrorMessage = "O campo {0} não pode ter mais de 150 caracteres!")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(2, ErrorMessage = "O campo {0} não pode ter mais de 2 caracteres!")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(150, ErrorMessage = "O campo {0} não pode ter mais de 150 caracteres!")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public int Number { get; set; }
    }
}
