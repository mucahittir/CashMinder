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
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public float Amount { get; set; }
        public TransactionType Type { get; set; } = TransactionType.Withdrawal;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid UserId { get; set; }
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
