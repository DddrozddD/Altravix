using Altavix.Application.Features.Products.DTOs;

namespace Altavix.Application.Features.Products.ViewModels;

public class ProductsListVm
{
    public IList<ProductDto> Products { get; set; } = new List<ProductDto>();
}
