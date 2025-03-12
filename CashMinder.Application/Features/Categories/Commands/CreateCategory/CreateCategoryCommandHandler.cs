using CashMinder.Application.Bases;
using CashMinder.Application.Features.Categories.Rules;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CashMinder.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly IValidator<CreateCategoryCommandRequest> validator;
        private readonly CategoryRules categoryRules;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCategoryCommandRequest> validator, CategoryRules categoryRules, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(mapper,unitOfWork,httpContextAccessor)
        {
            this.validator = validator;
            this.categoryRules = categoryRules;
        }
        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            IList<Category> categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            await categoryRules.CategoryNameShouldBeUnique(request.Name, categories);
            var map = mapper.Map<Category, CreateCategoryCommandRequest>(request);
            map.UserId = new Guid(userId);
            await unitOfWork.GetWriteRepository<Category>().AddAsync(map);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
