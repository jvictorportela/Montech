
using Montech.Communication.Responses.Usuario;
using Montech.Domain.Repositories.Usuario;

namespace Montech.Application.UseCases.Usuario.BuscarAtivos;

public class GetActiveUsersUseCase : IGetActivesUsersUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;

    public GetActiveUsersUseCase(IUsuarioReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task<List<ResponseActiveUsersJson>> GetAllActivesUsers()
    {
        var listActiveUser = await _readOnlyRepository.BuscarUsuarioAtivos();

        if (listActiveUser is null || !listActiveUser.Any())
            throw new ArgumentNullException(nameof(listActiveUser), "No active users found.");

        var response = new List<ResponseActiveUsersJson>();

        foreach (var activeUser in listActiveUser)
        {
            response.Add(new ResponseActiveUsersJson
            {
                Nome = activeUser.Nome,
                CpfOrCnpj = activeUser.CpfOrCnpj,
                Email = activeUser.Email
            });
        }

        return response;
    }
}
