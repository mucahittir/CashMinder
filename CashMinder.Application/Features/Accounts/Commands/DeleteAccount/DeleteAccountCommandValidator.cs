using FluentValidation;

namespace CashMinder.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommandRequest>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}