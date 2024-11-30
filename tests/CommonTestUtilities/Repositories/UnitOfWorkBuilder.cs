using Montech.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();

        //return (IUnitOfWork)mock;
        return mock.Object;
    }
}
