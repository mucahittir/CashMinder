using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMinder.Domain.Common;
using CashMinder.Domain.Enums;

namespace CashMinder.Domain.Entities
{
    public class RecurringTransaction : EntityBase
    {
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public TransactionFrequency Frequency { get; set; }
        public TransactionType Type { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public RecurringTransaction(string description, float amount, DateTime startDate, TransactionFrequency frequency, TransactionType type, Guid userId, Guid categoryId, Guid accountId)
        {
            Description = description;
            Amount = amount;
            StartDate = startDate;
            Frequency = frequency;
            Type = type;
            UserId = userId;
            CategoryId = categoryId;
            AccountId = accountId;
        }
    }
}
