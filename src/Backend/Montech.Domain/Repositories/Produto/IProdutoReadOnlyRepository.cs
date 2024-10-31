using Montech.Domain.Enums;

namespace Montech.Domain.Repositories.Produto;

public interface IProdutoReadOnlyRepository
{
    Task<List<Entities.Produto>> BuscarTodosOsProdutos(long idUsuario);
    Task<Entities.Produto> BuscarProdutoPorId(long idUsuario, long id);
    Task<Entities.Produto> BuscarProdutoPorNome(long idUsuario, string nome);
    Task<List<Entities.Produto>> BuscarProdutosPorCategoria(long idUsuario, CategoriaEnum idCategoria);
}
