using AutoMapper;
using Montech.Application.Services.Cryptography;
using Montech.Application.UseCases.Usuario.Criar;
using Montech.Communication.Requests.Usuario;
using Montech.Communication.Responses.Usuario;
using Montech.Domain.Repositories;
using Montech.Domain.Repositories.Usuario;
using Montech.Domain.Security.Tokens;

namespace Montech.Application.UseCases.Usuario.Registrar;

public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
{
    private readonly IUsuarioWriteOnlyRepository _writeOnlyRepository;
    private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CriptografiaSenha _senhaEncrypter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public RegistrarUsuarioUseCase(IUsuarioWriteOnlyRepository writeOnlyRepository, IUsuarioReadOnlyRepository readOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork, CriptografiaSenha senhaEncrypter, IAccessTokenGenerator accessTokenGenerator)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _senhaEncrypter = senhaEncrypter;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseUsuarioRegistradoJson> Execute(RequestRegistrarUsuarioJson request)
    {
        await Validate(request);

        var usuario = _mapper.Map<Domain.Entities.Usuario>(request);
        usuario.Senha = _senhaEncrypter.Encrypt(request.Senha);
        usuario.UserIdentifier = Guid.NewGuid();

        await _writeOnlyRepository.AdicionarUsuario(usuario);
        await _unitOfWork.Commit();

        return new ResponseUsuarioRegistradoJson
        {
            Nome = usuario.Nome,
            Tokens = new ResponseTokensJson
            {
                AccessToken = _accessTokenGenerator.Generate(usuario.UserIdentifier)
            }
        };
    }

    private async Task Validate(RequestRegistrarUsuarioJson request)
    {
        var validator = new ValidarRegistroUsuario();

        var result = validator.Validate(request);

        var emailExist = await _readOnlyRepository.ExisteUsuarioAtivoComEsseEmail(request.Email);

        if (emailExist)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, "Já existe um usuário com esse e-mail!"));


        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new Exception();
        }
    }
}
