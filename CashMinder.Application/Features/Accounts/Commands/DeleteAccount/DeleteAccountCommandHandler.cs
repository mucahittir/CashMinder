using CashMinder.Application.Bases;
using CashMinder.Application.Features.Accounts.Rules;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CashMinder.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : BaseHandler, IRequestHandler<DeleteAccountCommandRequest, Unit>
    {
        private readonly IValidator<DeleteAccountCommandRequest> validator;
        private readonly AccountRules accountRules;

        public DeleteAccountCommandHandler(IValidator<DeleteAccountCommandRequest> validator,AccountRules accountRules,IMapper? mapper, IUnitOfWork? unitOfWork, IHttpContextAccessor? httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.validator = validator;
            this.accountRules = accountRules;
        }

        public async Task<Unit> Handle(DeleteAccountCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            var account = await unitOfWork.GetReadRepository<Account>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);
            await accountRules.AccountShouldExist(account);
            account.IsDeleted = true;
            account.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.GetWriteRepository<Account>().UpdateAsync(account);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}