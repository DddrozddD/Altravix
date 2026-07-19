using Altavix.Application.Features.Categories.DTOs;

namespace Altavix.Application.Features.Categories.ViewModels;

public class CategoriesListVm
{
    public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
}
