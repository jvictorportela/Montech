using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.BuscarAtivos;

public interface IGetActivesUsersUseCase
{
    Task<List<ResponseActiveUsersJson>> GetAllActivesUsers();
}
