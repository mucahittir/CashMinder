using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Auth.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base("User not found") { }
    }
}