using CashMinder.Application.Features.Categories.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashMinder.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }
    }
}
