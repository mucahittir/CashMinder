using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("User already exists") { }
    }
}