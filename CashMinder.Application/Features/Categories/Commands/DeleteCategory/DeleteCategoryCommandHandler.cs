using CashMinder.Application.Bases;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : BaseHandler, IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly IValidator<DeleteCategoryCommandRequest> validator;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<DeleteCategoryCommandRequest> validator): base(null, unitOfWork, null)
        {
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
