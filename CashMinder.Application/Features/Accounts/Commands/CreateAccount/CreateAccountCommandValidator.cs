using FluentValidation;

namespace CashMinder.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommandRequest>
    {
        public CreateAccountCommandValidator()
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