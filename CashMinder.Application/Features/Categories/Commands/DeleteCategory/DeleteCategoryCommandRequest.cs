using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
