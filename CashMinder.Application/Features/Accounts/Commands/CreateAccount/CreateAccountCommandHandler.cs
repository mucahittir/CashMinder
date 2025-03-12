using CashMinder.Application.Bases;
using CashMinder.Application.Features.Accounts.Rules;
using CashMinder.Application.Interfaces.AutoMapper;
using CashMinder.Application.Interfaces.UnitOfWorks;
using CashMinder.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CashMinder.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : BaseHandler, IRequestHandler<CreateAccountCommandRequest, Unit>
    {
        private readonly IValidator<CreateAccountCommandRequest> validator;
        private readonly AccountRules accountRules;

        public CreateAccountCommandHandler(IValidator<CreateAccountCommandRequest> validator, AccountRules accountRules, IMapper? mapper, IUnitOfWork? unitOfWork, IHttpContextAccessor? httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.validator = validator;
            this.accountRules = accountRules;
        }

        public async Task<Unit> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);
            IList<Account> accounts = await unitOfWork.GetReadRepository<Account>().GetAllAsync();
            await accountRules.AccountNameShouldBeUnique(request.Name, accounts);
            var map = mapper.Map<Account, CreateAccountCommandRequest>(request);
            map.UserId = new Guid(userId);
            map.CreatedAt = DateTime.UtcNow;
            map.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.GetWriteRepository<Account>().AddAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}