using Montech.Domain.Enums;
using Montech.Domain.Repositories;
using Montech.Domain.Repositories.Produto;

namespace Montech.Infrastructure.Data.Repositories.Produto;

public class ProdutoRepository : IProdutoReadOnlyRepository, IProdutoWriteOnlyRepository
{
    private readonly MontechDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public ProdutoRepository(MontechDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task AdicionarProduto(Domain.Entities.Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _unitOfWork.Commit();
    }

    public Task AtualizarProduto(Domain.Entities.Produto produto)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Produto> BuscarProdutoPorId(long idUsuario, long id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Produto> BuscarProdutoPorNome(long idUsuario, string nome)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entities.Produto>> BuscarProdutosPorCategoria(long idUsuario, CategoriaEnum idCategoria)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entities.Produto>> BuscarTodosOsProdutos(long idUsuario)
    {
        throw new NotImplementedException();
    }

    public Task DeletarProduto(long idUsuario, long id)
    {
        throw new NotImplementedException();
    }
}
