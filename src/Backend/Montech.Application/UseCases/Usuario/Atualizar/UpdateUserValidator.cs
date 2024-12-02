using FluentValidation;
using FluentValidation.Validators;
using Montech.Communication.Requests.Usuario;
using Montech.Exceptions;

namespace Montech.Application.UseCases.Usuario.Atualizar;

public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
{
    public UpdateUserValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceMessagesExcpetions.NAME_EMPTY);
        RuleFor(request => request.Email).NotEmpty().WithMessage(ResourceMessagesExcpetions.EMAIL_EMPTY);

        When(request => string.IsNullOrWhiteSpace(request.Email).Equals(false), () =>
        {
            RuleFor(request => request.Email).EmailAddress().WithMessage(ResourceMessagesExcpetions.EMAIL_INVALID);
        });
    }
}
