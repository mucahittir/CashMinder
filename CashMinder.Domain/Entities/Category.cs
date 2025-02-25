using CashMinder.Domain.Common;

namespace CashMinder.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<RecurringTransaction> RecurringTransactions { get; set; }

        public Category(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }
        public Category()
        {
        }
    }
}
