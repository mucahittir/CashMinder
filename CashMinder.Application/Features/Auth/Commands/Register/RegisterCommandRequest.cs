using MediatR;

namespace CashMinder.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandRequest: IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}