using CashMinder.Application.Features.Accounts.Commands.CreateAccount;
using CashMinder.Application.Features.Accounts.Commands.DeleteAccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashMinder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteAccountCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}