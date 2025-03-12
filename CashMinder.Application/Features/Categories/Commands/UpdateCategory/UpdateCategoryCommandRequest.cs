
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
