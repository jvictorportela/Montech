using AutoMapper;
using Montech.Domain.Repositories.Usuario;
using Montech.Domain.Repositories;
using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Buscar;

public class BuscarUsuarioIdUseCase : IBuscarUsuarioIdUseCase
{
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;

    public BuscarUsuarioIdUseCase(IUsuarioReadOnlyRepository readOnlyRepository)
    {
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task<ResponseUsuarioBuscarId> BuscarUsuarioId(long id)
    {
        var usuario = await _readOnlyRepository.BuscarUsuario(id);

        if (usuario is null)
            throw new ArgumentNullException(nameof(usuario));


        return new ResponseUsuarioBuscarId
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
            CpfOrCnpj = usuario.CpfOrCnpj
        };
    }
}
