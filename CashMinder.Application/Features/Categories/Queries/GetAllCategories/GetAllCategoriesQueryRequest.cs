using MediatR;

namespace CashMinder.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<IList<GetAllCategoriesQueryResponse>>
    {
    }
}
