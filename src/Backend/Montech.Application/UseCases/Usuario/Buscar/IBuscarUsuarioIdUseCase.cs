using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Buscar;

public interface IBuscarUsuarioIdUseCase
{
    Task<ResponseUsuarioBuscarId> BuscarUsuarioId(long id);
}
