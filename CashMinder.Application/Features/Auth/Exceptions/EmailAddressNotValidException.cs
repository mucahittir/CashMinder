using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Auth.Exceptions
{
    public class EmailAddressNotValidException : BaseException
    {
        public EmailAddressNotValidException() : base("Email address is not valid") { }
    }
}