using FluentValidation;

namespace bemol.Business.Models.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 250)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(c => c.Phone)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} não pode ser vazio!")
               .Length(1, 12)
               .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode ser vazio!")
                .Length(1, 250)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!")
                .EmailAddress()
                .WithMessage("E-mail inválido!");

            RuleFor(c => c.Cpf)
                .Length(1, 14)
                .WithMessage("O campo {PropertyName} não pode ter mais de {1} caracteres!");
        }
    }
}
