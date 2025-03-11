using CashMinder.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Application.Features.Auth.Commands.RevokeAll
{
    public class RevokeAllCommandHandler : IRequestHandler<RevokeAllCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;

        public RevokeAllCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            var users = await userManager.Users.ToListAsync(cancellationToken);
            foreach (var user in users)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiryTime = null;
                await userManager.UpdateAsync(user);
            }
            return Unit.Value;

        }
    }
}