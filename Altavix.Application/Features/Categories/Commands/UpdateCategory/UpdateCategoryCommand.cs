using MediatR;

namespace Altavix.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}
