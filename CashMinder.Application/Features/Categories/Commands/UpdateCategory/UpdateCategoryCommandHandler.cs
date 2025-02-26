
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Category, UpdateCategoryCommandRequest>(request);
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
        }
    }
}
