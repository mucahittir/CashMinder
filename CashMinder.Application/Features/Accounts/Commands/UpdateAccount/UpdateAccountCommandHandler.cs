using CashMinder.Application.Bases;
using CashMinder.Application.Features.Accounts.Rules;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CashMinder.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : BaseHandler, IRequestHandler<UpdateAccountCommandRequest, Unit>
    {
        private readonly IValidator<UpdateAccountCommandRequest> validator;
        private readonly AccountRules accountRules;

        public UpdateAccountCommandHandler(IValidator<UpdateAccountCommandRequest> validator,AccountRules accountRules,IMapper? mapper, IUnitOfWork? unitOfWork, IHttpContextAccessor? httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.validator = validator;
            this.accountRules = accountRules;
        }

        public async Task<Unit> Handle(UpdateAccountCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            var account = await unitOfWork.GetReadRepository<Account>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);
            await accountRules.AccountShouldExist(account);
            var map = mapper.Map<Account, UpdateAccountCommandRequest>(request);
            map.UserId = new Guid(userId);
            map.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.GetWriteRepository<Account>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}