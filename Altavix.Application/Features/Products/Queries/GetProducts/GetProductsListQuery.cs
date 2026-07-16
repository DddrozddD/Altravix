using Altavix.Application.Features.Products.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Products.Queries.GetProducts;

public record GetProductsListQuery : IRequest<IEnumerable<ProductDto>>;

public class GetProductsListQueryHandler : BaseQueryHandler, IRequestHandler<GetProductsListQuery, IEnumerable<ProductDto>>
{
    public GetProductsListQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Name, 
                Description, 
                Price, 
                CategoryId 
            FROM Products";

        return await QueryAsync<ProductDto>(sql);
    }
}
