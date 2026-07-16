using Altavix.Application.Features.Categories.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Categories.Queries.GetCategoriesList;

public record GetCategoriesListQuery : IRequest<IEnumerable<CategoryDto>>;

public class GetCategoriesListQueryHandler : BaseQueryHandler, IRequestHandler<GetCategoriesListQuery, IEnumerable<CategoryDto>>
{
    public GetCategoriesListQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Title 
            FROM Categories";

        return await QueryAsync<CategoryDto>(sql);
    }
}
