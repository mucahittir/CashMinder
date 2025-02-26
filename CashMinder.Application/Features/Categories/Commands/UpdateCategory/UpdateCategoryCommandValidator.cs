using CashMinder.Application.Features.Categories.Commands.DeleteCategory;
using CashMinder.Application.Features.Categories.Commands.UpdateCategory;
using FluentValidation;

namespace CashMinder.Application.Features.Categories.Commands.CreateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.UserId)
                .NotEmpty();

        }
    }
}
