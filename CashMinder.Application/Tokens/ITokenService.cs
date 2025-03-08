using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CashMinder.Domain.Entities;

namespace CashMinder.Application.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
