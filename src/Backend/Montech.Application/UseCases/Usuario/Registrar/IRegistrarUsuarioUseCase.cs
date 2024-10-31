using Montech.Communication.Requests.Usuario;
using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Criar;

public interface IRegistrarUsuarioUseCase
{
     Task<ResponseUsuarioRegistradoJson> Execute(RequestRegistrarUsuarioJson request);
}
