using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using MediatR;

namespace CashMinder.Application.Features.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, IList<GetAllCategoriesQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            return categories.Select(c => new GetAllCategoriesQueryResponse
            {
                Name = c.Name
            }).ToList();
        }
    }
}
