using CashMinder.Application.Features.Categories.Commands.CreateCategory;
using CashMinder.Application.Features.Categories.Commands.DeleteCategory;
using CashMinder.Application.Features.Categories.Commands.UpdateCategory;
using CashMinder.Application.Features.Categories.Queries.GetAllCategories;
using CashMinder.Application.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await mediator.Send(new GetCategoryQueryRequest { Id = id });
            return Ok(response);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
