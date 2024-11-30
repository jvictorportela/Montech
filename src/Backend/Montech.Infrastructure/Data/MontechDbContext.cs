using Microsoft.EntityFrameworkCore;

namespace Montech.Infrastructure.Data;

public class MontechDbContext : DbContext
{
    public MontechDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }
    public DbSet<Domain.Entities.Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MontechDbContext).Assembly);
    }
}
