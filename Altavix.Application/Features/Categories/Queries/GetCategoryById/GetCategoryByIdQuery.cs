using Altavix.Application.Features.Categories.ViewModels;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryVm?>;
