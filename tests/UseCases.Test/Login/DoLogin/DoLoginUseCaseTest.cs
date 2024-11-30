using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Repositories;
using Montech.Application.UseCases.Usuario.Login.DoLogin;

namespace UseCases.Test.Login.DoLogin;

public class DoLoginUseCaseTest
{
    private static DoLoginUseCase CreateUseCase()
    {
        var passwordEncrypter = PasswordEncrypterBuilder.Build();
        var userReadOnlyRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

        return new DoLoginUseCase(userReadOnlyRepositoryBuilder.Build(), passwordEncrypter);
    }
}
