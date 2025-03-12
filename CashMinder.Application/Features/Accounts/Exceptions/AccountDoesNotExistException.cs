using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Accounts.Exceptions
{
    public class AccountDoesNotExistException : BaseException
    {
        public AccountDoesNotExistException() : base("Account does not exist."){}
    }
}