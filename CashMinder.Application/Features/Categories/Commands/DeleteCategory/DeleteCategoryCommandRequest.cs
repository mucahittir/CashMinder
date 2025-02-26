using MediatR;

namespace CashMinder.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
