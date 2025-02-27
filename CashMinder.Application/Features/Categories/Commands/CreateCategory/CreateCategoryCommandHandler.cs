
using System.ComponentModel.DataAnnotations;
using CashMinder.Application.Features.Categories.Rules;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CashMinder.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IValidator<CreateCategoryCommandRequest> validator;
        private readonly CategoryRules categoryRules;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCategoryCommandRequest> validator, CategoryRules categoryRules)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.categoryRules = categoryRules;
        }
        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            await categoryRules.CategoryNameShouldBeUnique(request.Name, categories);

            Category category = new Category
            {
                Name = request.Name,
                UserId = request.UserId
            };

            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
