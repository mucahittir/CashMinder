using CashMinder.Application.Bases;
using CashMinder.Application.DTOs;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : BaseHandler, IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        public GetCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper,unitOfWork, null)
        {
        }
        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted , include: x => x.Include(u => u.User));
            var user = mapper.Map<UserDto, User>(new User());
            var map = mapper.Map<GetCategoryQueryResponse, Category>(category);
            return map;
        }
    }
    
}
