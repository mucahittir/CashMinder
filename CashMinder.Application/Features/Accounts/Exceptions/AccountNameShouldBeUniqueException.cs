using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Accounts.Exceptions
{
    public class AccountNameShouldBeUniqueException : BaseException
    {
        public AccountNameShouldBeUniqueException() : base("Account name should be unique")
        {
        }
    }
}