namespace Montech.Domain.Repositories.Usuario;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExisteUsuarioAtivoComEsseEmail(string email);//GET
    Task<Entities.Usuario> BuscarUsuario(long id); //GET
    Task<List<Entities.Usuario>> BuscarUsuarioAtivos(); //GETALL
    Task<Entities.Usuario?> BuscarPorEmailESenha(string email, string senha);
    Task<bool> ExistActiveUserWithIdentifier(Guid userIdentifier);
}
