using CashMinder.Application.Bases;
using CashMinder.Application.Features.Accounts.Exceptions;
using CashMinder.Domain.Entities;

namespace CashMinder.Application.Features.Accounts.Rules
{
    public class AccountRules : BaseRules
    {
        public Task AccountNameShouldBeUnique(string requestName, IList<Account> accounts)
        {
            if(accounts.Any(x => x.Name == requestName)) throw new AccountNameShouldBeUniqueException();
            return Task.CompletedTask;
        }

        public Task AccountShouldExist(Account account)
        {
            if(account == null) throw new AccountDoesNotExistException();
            return Task.CompletedTask;
        }
    }
}