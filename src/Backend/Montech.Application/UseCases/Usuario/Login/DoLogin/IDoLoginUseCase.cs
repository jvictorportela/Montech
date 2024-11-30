using Montech.Communication.Requests.Login;
using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Login.DoLogin;

public interface IDoLoginUseCase
{
    Task<ResponseUsuarioRegistradoJson> Execute(RequestLoginJson request);
}
