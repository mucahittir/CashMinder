using MediatR;

namespace CashMinder.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandRequest : IRequest<Unit>
    {
        public Guid Id {get; set;}
    }
}