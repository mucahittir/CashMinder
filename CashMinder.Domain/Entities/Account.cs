using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMinder.Domain.Common;
using CashMinder.Domain.Enums;

namespace CashMinder.Domain.Entities
{
    public class Account : EntityBase
    {

        public string Name { get; set; }
        public float Balance { get; set; } = 0;
        public AccountType Type { get; set; }
        public Currency Currency { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<RecurringTransaction> RecurringTransactions { get; set; }
        public Account(string name, float balance ,AccountType type, Currency currency, Guid userId)
        {
            Name = name;
            Balance = balance;
            Type = type;
            Currency = currency;
            UserId = userId;
        }
        public Account()
        {
            
        }
    }
}
