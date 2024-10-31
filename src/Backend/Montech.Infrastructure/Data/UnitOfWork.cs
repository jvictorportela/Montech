using Montech.Domain.Repositories;

namespace Montech.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly MontechDbContext _context;

    public UnitOfWork(MontechDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}
