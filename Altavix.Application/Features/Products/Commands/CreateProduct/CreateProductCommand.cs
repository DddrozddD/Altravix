using MediatR;

namespace Altavix.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int PriceCoin {get; set;}
    public Guid UserCreatorId {get; set;}
    public List<Guid> CategoryIds {get; set;}
}