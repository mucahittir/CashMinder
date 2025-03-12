
using CashMinder.Application.Bases;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CashMinder.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : BaseHandler,IRequestHandler<UpdateCategoryCommandRequest,Unit>
    {
        private readonly IValidator<UpdateCategoryCommandRequest> validator;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCategoryCommandRequest> validator, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.validator = validator;
        }
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            var category = await unitOfWork.GetReadRepository<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Category, UpdateCategoryCommandRequest>(request);
            map.UserId = new Guid(userId);
            await unitOfWork.GetWriteRepository<Category>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
