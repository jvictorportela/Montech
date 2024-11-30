namespace Montech.Domain.Repositories.Usuario;

public interface IUsuarioWriteOnlyRepository
{
    Task AdicionarUsuario(Entities.Usuario usuario); //POST
    Task<Entities.Usuario> AtualizarUsuario(Entities.Usuario usuario); //PUT
    Task<Entities.Usuario> DeletarUsuario(long id); //DELETE
}
