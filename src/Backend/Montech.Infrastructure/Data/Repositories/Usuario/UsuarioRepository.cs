using Microsoft.EntityFrameworkCore;
using Montech.Domain.Repositories;
using Montech.Domain.Repositories.Usuario;

namespace Montech.Infrastructure.Data.Repositories.Usuario;

public class UsuarioRepository : IUsuarioReadOnlyRepository, IUsuarioWriteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly MontechDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioRepository(MontechDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task AdicionarUsuario(Domain.Entities.Usuario usuario) //OK
    {
        await _context.Usuarios.AddAsync(usuario);
        await _unitOfWork.Commit();
    }

    public async Task<Domain.Entities.Usuario> AtualizarUsuario(Domain.Entities.Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _unitOfWork.Commit();
        return usuario;
    }

    public async Task<Domain.Entities.Usuario?> BuscarPorEmailESenha(string email, string senha) //OK
    {
        return await _context
            .Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Ativo && user.Email.Equals(email) && user.Senha.Equals(senha));
    }

    public async Task<Domain.Entities.Usuario?> BuscarUsuario(long id) //OK
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<List<Domain.Entities.Usuario>> BuscarUsuarioAtivos() //OK
    {
        return await _context.Usuarios
            .Where(u => u.Ativo == true)
            .ToListAsync();
    }

    public async Task<Domain.Entities.Usuario> DeletarUsuario(long id) //...
    {
        var usuarioRemover = await _context.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();
        _context.Usuarios.Remove(usuarioRemover!);
        await _unitOfWork.Commit();
        return usuarioRemover!;
    }

    public async Task<bool> ExisteUsuarioAtivoComEsseEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(u => u.Email.Equals(email) && u.Ativo);
    }

    public async Task<bool> ExistActiveUserWithIdentifier(Guid userIdentifier)
    {
        return await _context.Usuarios.AnyAsync(user => user.UserIdentifier.Equals(userIdentifier) && user.Ativo);
    }

    public async Task<Domain.Entities.Usuario> GetById(long id)
    {
        return await _context.Usuarios.FirstAsync(u => u.Id == id);
    }

    public void Update(Domain.Entities.Usuario user) => _context.Usuarios.Update(user);
}
