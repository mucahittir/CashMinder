using CashMinder.Application.Features.Categories.Commands.DeleteCategory;
using FluentValidation;

namespace CashMinder.Application.Features.Categories.Commands.CreateCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
