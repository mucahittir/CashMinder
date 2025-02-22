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

        public required string Name { get; set; }
        public required AccountType Type { get; set; }
        public required Currency Currency { get; set; }
        public required Guid UserId { get; set; }
        public User User { get; set; }
        public Account(string name, AccountType type, Currency currency, Guid userId)
        {
            Name = name;
            Type = type;
            Currency = currency;
            UserId = userId;
        }
        public Account()
        {
            
        }
    }
}
