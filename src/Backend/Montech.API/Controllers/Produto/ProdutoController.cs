using Microsoft.AspNetCore.Mvc;
using Montech.Application.UseCases.Produto.Created;
using Montech.Communication.Requests.Produto;
using Montech.Communication.Responses.Produto;

namespace Montech.API.Controllers.Produto;

[Route("[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreatedProdutoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Created([FromServices] ICreatedProductUseCase useCase, [FromBody] RequestCreatedProductJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
