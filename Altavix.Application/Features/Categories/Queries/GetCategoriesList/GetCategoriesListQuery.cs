using Altavix.Application.Features.Categories.ViewModels;
using MediatR;

namespace Altavix.Application.Features.Categories.Queries.GetCategoriesList;

public record GetCategoriesListQuery : IRequest<CategoriesListVm>;
