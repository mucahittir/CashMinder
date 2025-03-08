using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CashMinder.Application.Tokens;
using CashMinder.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CashMinder.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> userManager;
        private readonly TokenSettings tokenSettings;


        public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
        {
            this.userManager = userManager;
            tokenSettings = options.Value;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer : tokenSettings.Issuer,
                audience : tokenSettings.Audience,
                claims : claims,
                expires : DateTime.UtcNow.AddMinutes(tokenSettings.TokenExpirationInMinutes),
                signingCredentials : new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

            );
            await userManager.AddClaimsAsync(user,claims);
            return token;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken()
        {
            throw new NotImplementedException();
        }

    }
}

