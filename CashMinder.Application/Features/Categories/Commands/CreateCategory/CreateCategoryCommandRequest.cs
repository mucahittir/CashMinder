
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<Unit>
    {

        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
