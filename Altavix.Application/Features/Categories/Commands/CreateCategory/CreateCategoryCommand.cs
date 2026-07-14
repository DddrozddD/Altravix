using MediatR;

namespace Altavix.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Title { get; set; }
}
