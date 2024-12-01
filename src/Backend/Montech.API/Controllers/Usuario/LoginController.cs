using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montech.Application.UseCases.Usuario.Login.DoLogin;
using Montech.Communication.Requests.Login;
using Montech.Communication.Responses;
using Montech.Communication.Responses.Usuario;

namespace Montech.API.Controllers.Usuario;

[Route("[controller]")]
[ApiController]
public class LoginController : MontechBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUsuarioRegistradoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IDoLoginUseCase useCase, [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}
