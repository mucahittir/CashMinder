using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CashMinder.Application.Features.Auth.Rules;
using CashMinder.Application.Tokens;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CashMinder.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        
        private readonly AuthRules authRules;
        private readonly ITokenService tokenService;
        private readonly UserManager<User> userManager;
        private IValidator<RefreshTokenCommandRequest> validator;

        public RefreshTokenCommandHandler(AuthRules authRules, ITokenService tokenService, UserManager<User> userManager, IValidator<RefreshTokenCommandRequest> validator)
        {
            this.authRules = authRules;
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.validator = validator;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string? email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);

            await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);
            var newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);
            return new RefreshTokenCommandResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        
        }
    }
}