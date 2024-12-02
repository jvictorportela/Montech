using Montech.Communication.Requests.Usuario;
using Montech.Domain.Repositories;
using Montech.Domain.Repositories.Usuario;
using Montech.Domain.Services.LoggedUser;
using Montech.Exceptions.ExceptionBase;

namespace Montech.Application.UseCases.Usuario.Atualizar;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IUserUpdateOnlyRepository _repository;
    private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserUseCase(ILoggedUser loggedUser, IUserUpdateOnlyRepository repository, IUsuarioReadOnlyRepository usuarioReadOnlyRepository, IUnitOfWork unitOfWork)
    {
        _loggedUser = loggedUser;
        _repository = repository;
        _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestUpdateUserJson request)
    {
        var loggedUser = await _loggedUser.User();

        await Validate(request, loggedUser.Email);

        var user = await _repository.GetById(loggedUser.Id);

        user.Nome = request.Name;
        user.Email = request.Email;

        _repository.Update(user);

        await _unitOfWork.Commit();
    }

    private async Task Validate(RequestUpdateUserJson request, string currentEmail)
    {
        var validator = new UpdateUserValidator();

        var result = validator.Validate(request);

        if (!currentEmail.Equals(request.Email))
        {
            var userExist = await _usuarioReadOnlyRepository.ExisteUsuarioAtivoComEsseEmail(request.Email);
            if (userExist)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", "E-mail já registrado"));
        }

        if (result.IsValid.Equals(false))
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
