using FluentValidation;

namespace CashMinder.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidation : AbstractValidator<UpdateAccountCommandRequest>
    {
        public UpdateAccountCommandValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Balance)
                .NotNull();
            RuleFor(x => x.Type)
                .IsInEnum();
            RuleFor(x => x.Currency)
                .IsInEnum();
        }
    }
}