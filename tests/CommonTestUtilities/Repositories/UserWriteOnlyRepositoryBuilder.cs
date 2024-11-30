using Montech.Domain.Repositories.Usuario;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UserWriteOnlyRepositoryBuilder
{
    public static IUsuarioWriteOnlyRepository Build()
    {
        var mock = new Mock<IUsuarioWriteOnlyRepository>();

        //return (IUserWriteOnlyRepository)mock;
        return mock.Object;
    }
}
