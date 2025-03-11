using FluentValidation;

namespace CashMinder.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("Refresh token is required");
            RuleFor(x => x.AccessToken)
                .NotEmpty().WithMessage("Access token is required");
        }
    }
}