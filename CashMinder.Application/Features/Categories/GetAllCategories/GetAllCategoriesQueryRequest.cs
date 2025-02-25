using MediatR;

namespace CashMinder.Application.Features.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
