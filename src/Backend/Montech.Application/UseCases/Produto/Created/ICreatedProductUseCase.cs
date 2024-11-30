using Montech.Communication.Requests.Produto;
using Montech.Communication.Responses.Produto;

namespace Montech.Application.UseCases.Produto.Created;

public interface ICreatedProductUseCase
{
    Task<ResponseCreatedProdutoJson> Execute(RequestCreatedProductJson request);
}
