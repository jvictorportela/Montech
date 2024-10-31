namespace Montech.Domain.Repositories.Produto;

public interface IProdutoWriteOnlyRepository
{
    Task AdicionarProduto(Entities.Produto produto);
    Task AtualizarProduto(Entities.Produto produto);
    Task DeletarProduto(long idUsuario, long id);
}
