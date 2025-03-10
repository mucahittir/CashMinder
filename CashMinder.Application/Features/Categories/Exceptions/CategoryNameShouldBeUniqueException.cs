using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMinder.Application.Bases;

namespace CashMinder.Application.Features.Categories.Exceptions
{
    public class CategoryNameShouldBeUniqueException : BaseException
    {
        public CategoryNameShouldBeUniqueException(): base("Category name is already exist."){ }
    }
}
