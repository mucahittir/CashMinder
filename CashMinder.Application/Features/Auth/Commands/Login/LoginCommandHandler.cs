using System.IdentityModel.Tokens.Jwt;
using CashMinder.Application.Features.Auth.Rules;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Application.Tokens;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CashMinder.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private IValidator<LoginCommandRequest> validator;

        public LoginCommandHandler(AuthRules authRules, ITokenService tokenService, IConfiguration configuration, UserManager<User> userManager, IValidator<LoginCommandRequest> validator)
        {
            this.authRules = authRules;
            this.tokenService = tokenService;
            this.configuration = configuration;
            this.userManager = userManager;
            this.validator = validator;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            User? user = await userManager.FindByEmailAsync(request.Email);
            await authRules.UserShouldExist(user);
            bool passwordValid = await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.PasswordShouldBeValid(passwordValid);

            IList<string> roles = await userManager.GetRolesAsync(user);
            var accessToken = await tokenService.CreateToken(user, roles);

            _ = int.TryParse(configuration["JWT:RefreshTokenExpirationInDays"], out int refreshTokenExpirationInDays);
            _ = int.TryParse(configuration["JWT:TokenExpirationInMinutes"], out int tokenExpirationInMinutes);

            string refreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenExpirationInDays);
            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string token = new JwtSecurityTokenHandler().WriteToken(accessToken);
            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", token);
            return new LoginCommandResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(tokenExpirationInMinutes)
            };
        }
    }
}