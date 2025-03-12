using CashMinder.Domain.Enums;
using MediatR;

namespace CashMinder.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public AccountType Type { get; set; }
        public Currency Currency { get; set; }
    }
}