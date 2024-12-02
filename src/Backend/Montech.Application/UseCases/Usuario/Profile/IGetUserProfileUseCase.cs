using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Profile;

public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
