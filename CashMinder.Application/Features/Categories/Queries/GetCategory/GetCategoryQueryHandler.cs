using CashMinder.Application.DTOs;
using CashMinder.Application.Features.Categories.Queries.GetAllCategories;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using MediatR;

namespace CashMinder.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var user = mapper.Map<UserDto, User>(new User());
            var map = mapper.Map<GetCategoryQueryResponse, Category>(category);
            return map;
        }
    }
    
}
