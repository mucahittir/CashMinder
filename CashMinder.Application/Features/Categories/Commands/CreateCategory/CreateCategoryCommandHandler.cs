
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Name = request.Name,
                UserId = request.UserId
            };

            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();

        }
    }
}
