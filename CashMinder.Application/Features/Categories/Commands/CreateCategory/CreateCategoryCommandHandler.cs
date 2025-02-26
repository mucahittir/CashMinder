
using System.ComponentModel.DataAnnotations;
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

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCategoryCommandRequest> validator)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }
        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
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
