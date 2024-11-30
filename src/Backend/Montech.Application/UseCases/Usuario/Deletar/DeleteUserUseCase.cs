
using Montech.Communication.Responses.Usuario;
using Montech.Domain.Repositories;
using Montech.Domain.Repositories.Usuario;

namespace Montech.Application.UseCases.Usuario.Deletar;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUsuarioWriteOnlyRepository _writeOnlyRepository;

    public DeleteUserUseCase(IUsuarioWriteOnlyRepository writeOnlyRepository)
    {
        _writeOnlyRepository = writeOnlyRepository;
    }

    public async Task<ResponseActiveUsersJson> DeleteUser(long userId)
    {
        var response = await _writeOnlyRepository.DeletarUsuario(userId);

        return new ResponseActiveUsersJson
        {
            Nome = response.Nome,
            CpfOrCnpj = response.CpfOrCnpj,
            Email = response.Email
        };
    }
}
