using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Auth.Exceptions
{
    public class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException() : base("Invalid password") { }
    }
}