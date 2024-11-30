using Montech.Domain.Repositories.Usuario;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUsuarioReadOnlyRepository> _repository;

    //ctor
    public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUsuarioReadOnlyRepository>();

    public void ExistActiveUserWithEmail(string email)
    {
        _repository.Setup(repository => repository.ExisteUsuarioAtivoComEsseEmail(email)).ReturnsAsync(true);
    }

    public IUsuarioReadOnlyRepository Build() => /*return*/ _repository.Object;
}
