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
    }
}