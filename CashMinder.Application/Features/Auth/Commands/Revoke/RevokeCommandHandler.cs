using CashMinder.Application.Features.Auth.Rules;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CashMinder.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        IValidator<RevokeCommandRequest> validator;
        public RevokeCommandHandler(AuthRules authRules,  UserManager<User> userManager, IValidator<RevokeCommandRequest> validator)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.validator = validator;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            User? user = userManager.FindByEmailAsync(request.Email).Result;
            
            await authRules.EmailAddressShouldBeValid(user);
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await userManager.UpdateAsync(user);
            return Unit.Value;

        }
    }
}