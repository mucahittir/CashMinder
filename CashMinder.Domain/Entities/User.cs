using Microsoft.AspNetCore.Identity;

namespace CashMinder.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<RecurringTransaction> RecurringTransactions { get; set; }
    }
}
