using Altavix.Application.Features.Products.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;

public class GetProductByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public GetProductByIdQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Name, 
                Description, 
                Price, 
                CategoryId 
            FROM Products 
            WHERE Id = @Id";

        return await QueryFirstOrDefaultAsync<ProductDto>(sql, new { request.Id });
    }
}
