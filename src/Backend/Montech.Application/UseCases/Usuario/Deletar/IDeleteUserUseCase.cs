using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Deletar;

public interface IDeleteUserUseCase
{
    Task<ResponseActiveUsersJson> DeleteUser(long userId);
}
