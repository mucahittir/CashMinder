using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMinder.Domain.Common;

namespace CashMinder.Domain.Entities
{
    public class Category : EntityBase
    {
        public required string Name { get; set; }
        public required Guid UserId { get; set; }
        public User User { get; set; }
        public Category(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
