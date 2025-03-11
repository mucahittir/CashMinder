using CashMinder.Application.Bases;
using CashMinder.Application.Features.Auth.Exceptions;
using CashMinder.Domain.Entities;

namespace CashMinder.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotExist(User? user)
        {
            if (user != null)
            {
                throw new UserAlreadyExistException();
            }
            return Task.CompletedTask;
        }

        public Task UserShouldExist(User? user)
        {
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return Task.CompletedTask;
        }

        public Task PasswordShouldBeValid(bool passwordValid)
        {
            if (!passwordValid)
            {
                throw new InvalidPasswordException();
            }
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldNotBeExpired(DateTime? refreshTokenExpiryTime)
        {
            if (refreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new RefreshTokenExpiredException();
            }
            return Task.CompletedTask;
        }
    }
}