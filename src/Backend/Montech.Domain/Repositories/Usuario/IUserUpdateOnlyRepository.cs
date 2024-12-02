namespace Montech.Domain.Repositories.Usuario;

public interface IUserUpdateOnlyRepository
{
    Task<Entities.Usuario> GetById(long id);
    public void Update(Entities.Usuario user);
}
