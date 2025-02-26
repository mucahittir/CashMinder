using CashMinder.Application.DTOs;

namespace CashMinder.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQueryResponse
    {
        public string Name { get; set; }
        public UserDto User { get; set; }
    }
}
