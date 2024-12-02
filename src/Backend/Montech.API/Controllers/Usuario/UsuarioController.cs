using Microsoft.AspNetCore.Mvc;
using Montech.API.Attributes;
using Montech.Application.UseCases.Usuario.Atualizar;
using Montech.Application.UseCases.Usuario.Buscar;
using Montech.Application.UseCases.Usuario.BuscarAtivos;
using Montech.Application.UseCases.Usuario.Criar;
using Montech.Application.UseCases.Usuario.Deletar;
using Montech.Application.UseCases.Usuario.Profile;
using Montech.Communication.Requests.Usuario;
using Montech.Communication.Responses;
using Montech.Communication.Responses.Usuario;

namespace Montech.API.Controllers.Usuario;

[AuthenticatedUser]
public class UsuarioController : MontechBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUsuarioRegistradoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegistrarUsuarioUseCase useCase,
        [FromBody] RequestRegistrarUsuarioJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseUsuarioBuscarId), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById([FromServices]IBuscarUsuarioIdUseCase useCase, long id)
    {
        var result = await useCase.BuscarUsuarioId(id);

        return Ok(result);
    }

    [HttpGet("ativos")]
    [ProducesResponseType(typeof(List<ResponseActiveUsersJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllActiveUsers([FromServices] IGetActivesUsersUseCase useCase)
    {
        var result = await useCase.GetAllActivesUsers();

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
    [AuthenticatedUser]
    public async Task<IActionResult> GetUserProfile([FromServices] IGetUserProfileUseCase useCase)
    {
        var result = await useCase.Execute();

        return Ok(result);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> Update([FromServices] IUpdateUserUseCase useCase, [FromBody] RequestUpdateUserJson request)
    {
        await useCase.Execute(request);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById([FromServices] IDeleteUserUseCase useCase, long id)
    {
        var result = await useCase.DeleteUser(id);

        return Ok(result);
    }
}
