using Altavix.Application.Features.Products.Commands.CreateProduct;
using Altavix.Application.Features.Products.Commands.UpdateProduct;
using Altavix.Application.Features.Products.Commands.DeleteProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AltavixAPI.Controllers;

public class ProductController : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] UpdateProductCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteProductCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}
