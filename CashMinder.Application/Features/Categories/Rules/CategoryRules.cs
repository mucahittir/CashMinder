using CashMinder.Application.Bases;
using CashMinder.Application.Features.Categories.Exceptions;
using CashMinder.Domain.Entities;

namespace CashMinder.Application.Features.Categories.Rules
{
    public class CategoryRules : BaseRules
    {
        public Task CategoryNameShouldBeUnique(string requestName, IList<Category> categories)
        {
            if(categories.Any(x => x.Name == requestName)) throw new CategoryNameShouldBeUniqueException();
            return Task.CompletedTask;
        }
    }
}
