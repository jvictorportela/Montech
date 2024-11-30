using AutoMapper;
using Montech.Communication.Requests.Produto;
using Montech.Communication.Responses.Produto;
using Montech.Domain.Repositories;
using Montech.Domain.Repositories.Produto;

namespace Montech.Application.UseCases.Produto.Created;

public class CreatedProductUseCase : ICreatedProductUseCase
{
    private readonly IProdutoWriteOnlyRepository _writeOnlyRepository;
    private readonly IProdutoReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreatedProductUseCase(IProdutoWriteOnlyRepository writeOnlyRepository, IProdutoReadOnlyRepository readOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseCreatedProdutoJson> Execute(RequestCreatedProductJson request)
    {
        var product = _mapper.Map<Domain.Entities.Produto>(request);

        await _writeOnlyRepository.AdicionarProduto(product);

        await _unitOfWork.Commit();

        return new ResponseCreatedProdutoJson
        {
            Nome = product.Nome,
            Categoria = product.Categoria,
            Usuario = product.Usuario,
            UsuarioId = product.UsuarioId
        };
    }
}
