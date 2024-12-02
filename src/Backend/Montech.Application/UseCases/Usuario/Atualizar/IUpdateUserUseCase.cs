using Montech.Communication.Requests.Usuario;

namespace Montech.Application.UseCases.Usuario.Atualizar;

public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}
