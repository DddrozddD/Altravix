using Altavix.Application.Features.Products.ViewModels;
using MediatR;

namespace Altavix.Application.Features.Products.Queries.GetProducts;

public record GetProductsListQuery : IRequest<ProductsListVm>;
