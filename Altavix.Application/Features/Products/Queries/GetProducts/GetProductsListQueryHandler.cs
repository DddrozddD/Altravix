using Altavix.Application.Features.Products.ViewModels;
using Altavix.Application.Features.Products.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Products.Queries.GetProducts;

public class GetProductsListQueryHandler : BaseQueryHandler, IRequestHandler<GetProductsListQuery, ProductsListVm>
{
    public GetProductsListQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<ProductsListVm> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Name, 
                Description, 
                Price, 
                CategoryId 
            FROM Products";

        var products = await QueryAsync<ProductDto>(sql);

        return new ProductsListVm
        {
            Products = products.ToList()
        };
    }
}

