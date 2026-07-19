using Altavix.Application.Features.Products.ViewModels;
using Altavix.Application.Interfaces;
using MediatR;


namespace Altavix.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetProductByIdQuery, ProductVm?>
{
    public GetProductByIdQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<ProductVm?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
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

        return await QueryFirstOrDefaultAsync<ProductVm>(sql, new { request.Id });
    }
}

