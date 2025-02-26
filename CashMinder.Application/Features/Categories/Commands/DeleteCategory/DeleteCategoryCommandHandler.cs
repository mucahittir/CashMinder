using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IValidator<DeleteCategoryCommandRequest> validator;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteCategoryCommandRequest> validator)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }
        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            category.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
