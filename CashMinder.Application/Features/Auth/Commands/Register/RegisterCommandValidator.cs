using System.Data;
using FluentValidation;

namespace CashMinder.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MaximumLength(50).WithMessage("First Name must not exceed 50 characters");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .MaximumLength(50).WithMessage("Last Name must not exceed 50 characters");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}