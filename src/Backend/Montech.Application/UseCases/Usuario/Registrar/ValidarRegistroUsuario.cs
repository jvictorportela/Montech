using FluentValidation;
using Montech.Communication.Requests.Usuario;

namespace Montech.Application.UseCases.Usuario.Registrar;

public class ValidarRegistroUsuario : AbstractValidator<RequestRegistrarUsuarioJson>
{
    public ValidarRegistroUsuario()
    {
        RuleFor(user => user.Nome).NotEmpty().WithMessage("O campo nome não pode ser nulo!");
        RuleFor(user => user.Email).NotEmpty().WithMessage("O campo Email não pode ser nulo!");
        RuleFor(user => user.Senha).NotEmpty().WithMessage("O campo senha não pode ser nulo!");
        RuleFor(user => user.CpfOrCnpj).NotEmpty().WithMessage("O campo CPF/CNPJ não pode ser nulo!");
        When(user => string.IsNullOrEmpty(user.Senha) == false, () =>
        {
            RuleFor(user => user.Senha.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve conter 6 ou mais caractéres");
        });
        When(user => string.IsNullOrEmpty(user.CpfOrCnpj) == false, () =>
        {
            RuleFor(user => user.CpfOrCnpj.Length).Equal(11).WithMessage("O campo CPF/CNJP deve conter 11 caractéres");
        });
        When(user => string.IsNullOrEmpty(user.Email) == false, () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage("O e-mail é inválido!");
        });
    }
}
