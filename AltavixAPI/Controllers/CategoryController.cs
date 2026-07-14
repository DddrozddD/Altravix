using Altavix.Application.Features.Categories.Commands.CreateCategory;
using Altavix.Application.Features.Categories.Commands.UpdateCategory;
using Altavix.Application.Features.Categories.Commands.DeleteCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AltavixAPI.Controllers;

public class CategoryController : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteCategoryCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}
