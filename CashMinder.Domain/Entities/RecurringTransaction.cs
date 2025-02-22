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
        public required string Description { get; set; }
        public required float Amount { get; set; }
        public required DateTime StartDate { get; set; } = DateTime.Now;
        public required TransactionFrequency Frequency { get; set; }
        public required TransactionType Type { get; set; }

        public required Guid UserId { get; set; }
        public User User { get; set; }
        public required Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public required Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
