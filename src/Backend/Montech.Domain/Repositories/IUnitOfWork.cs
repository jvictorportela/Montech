namespace Montech.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
