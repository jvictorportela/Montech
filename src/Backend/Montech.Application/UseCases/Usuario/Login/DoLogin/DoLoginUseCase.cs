using Montech.Application.Services.Cryptography;
using Montech.Communication.Requests.Login;
using Montech.Communication.Responses.Usuario;
using Montech.Domain.Repositories.Usuario;
using Montech.Domain.Security.Tokens;
using Montech.Exceptions.ExceptionBase;

namespace Montech.Application.UseCases.Usuario.Login.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUsuarioReadOnlyRepository _repository;
    private readonly CriptografiaSenha _senhaEcripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(IUsuarioReadOnlyRepository repository, CriptografiaSenha senhaEcripter, IAccessTokenGenerator accessTokenGenerator)
    {
        _repository = repository;
        _senhaEcripter = senhaEcripter;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseUsuarioRegistradoJson> Execute(RequestLoginJson request)
    {
        var senhaCriptografada = _senhaEcripter.Encrypt(request.Senha);

        var user = await _repository.BuscarPorEmailESenha(request.Email, senhaCriptografada) ?? throw new InvalidLoginException();

        //if (user is null)
        //throw new InvalidLoginException();

        return new ResponseUsuarioRegistradoJson
        {
            Nome = user.Nome,
            Tokens = new ResponseTokensJson
            {
                AccessToken = _accessTokenGenerator.Generate(user.UserIdentifier)
            }
        };
    }
}
