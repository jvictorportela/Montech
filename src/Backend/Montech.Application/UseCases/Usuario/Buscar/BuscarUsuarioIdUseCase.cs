using AutoMapper;
using Montech.Domain.Repositories.Usuario;
using Montech.Domain.Repositories;
using Montech.Communication.Responses.Usuario;

namespace Montech.Application.UseCases.Usuario.Buscar;

public class BuscarUsuarioIdUseCase : IBuscarUsuarioIdUseCase
{
    private readonly IUsuarioWriteOnlyRepository _writeOnlyRepository;
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BuscarUsuarioIdUseCase(IUsuarioWriteOnlyRepository writeOnlyRepository, IUsuarioReadOnlyRepository readOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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
