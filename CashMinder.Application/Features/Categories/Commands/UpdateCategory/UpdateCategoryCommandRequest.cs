
using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

    }
}
