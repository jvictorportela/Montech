using Microsoft.EntityFrameworkCore;
using Montech.Domain.Entities;
using Montech.Domain.Security.Tokens;
using Montech.Domain.Services.LoggedUser;
using Montech.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Montech.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly MontechDbContext _context;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(MontechDbContext context, ITokenProvider tokenProvider)
    {
        _context = context;
        _tokenProvider = tokenProvider;
    }

    public async Task<Usuario> User()
    {
        var token = _tokenProvider.Value();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

        var userIdentifier = Guid.Parse(identifier);

        return await _context.Usuarios.AsNoTracking().FirstAsync(user => user.Ativo && user.UserIdentifier == userIdentifier);
    }
}
