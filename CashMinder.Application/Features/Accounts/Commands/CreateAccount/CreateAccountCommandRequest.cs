using CashMinder.Domain.Enums;
using MediatR;

namespace CashMinder.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public float Balance { get; set; }
        public AccountType Type { get; set; }
        public Currency Currency { get; set; }
    }
}