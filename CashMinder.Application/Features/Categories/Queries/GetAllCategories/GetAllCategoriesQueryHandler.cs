using CashMinder.Application.Bases;
using CashMinder.Application.DTOs;
using CashMinder.Application.Features.Categories.Queries.GetAllCategories;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CashMinder.Application.Features.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : BaseHandler, IRequestHandler<GetAllCategoriesQueryRequest, IList<GetAllCategoriesQueryResponse>>
    {
        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper): base(mapper, unitOfWork, null)
        {
        }
        public async Task<IList<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x => x.IsDeleted == false , include: x => x.Include(u => u.User));
            UserDto user = mapper.Map<UserDto, User>(new User());
            var map = mapper.Map<GetAllCategoriesQueryResponse, Category>(categories);
            return map;
        }
    }
}
