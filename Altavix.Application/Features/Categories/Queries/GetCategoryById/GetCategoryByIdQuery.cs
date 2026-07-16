using Altavix.Application.Features.Categories.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;

public class GetCategoryByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    public GetCategoryByIdQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Title 
            FROM Categories 
            WHERE Id = @Id";

        return await QueryFirstOrDefaultAsync<CategoryDto>(sql, new { request.Id });
    }
}
