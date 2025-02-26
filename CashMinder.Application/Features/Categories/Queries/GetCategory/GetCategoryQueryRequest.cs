using CashMinder.Application.DTOs;
using MediatR;

namespace CashMinder.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQueryRequest : IRequest<GetCategoryQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
