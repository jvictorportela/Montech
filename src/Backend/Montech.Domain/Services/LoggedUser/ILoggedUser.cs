namespace Montech.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<Entities.Usuario> User();
}
