using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMinder.Domain.Common;
using CashMinder.Domain.Enums;

namespace CashMinder.Domain.Entities
{
    public class Transaction : EntityBase
    {
        public required DateTime TransactionDate { get; set; } = DateTime.Now;
        public required string Description { get; set; }
        public required float Amount { get; set; }
        public required TransactionType Type { get; set; } = TransactionType.Withdrawal;

        public required Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public required Guid AccountId { get; set; }
        public Account Account { get; set; }
        public required Guid UserId { get; set; }
        public User User { get; set; }

        public Transaction(DateTime transactionDate, string description, float amount, TransactionType type, Guid categoryId,Guid accountId,Guid userId)
        {
            TransactionDate = transactionDate;
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            AccountId = accountId;
            UserId = userId;
        }

    }
}
