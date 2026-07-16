using Altavix.Application.Features.Roles.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Roles.Queries.GetRolesList;

public record GetRolesListQuery : IRequest<IEnumerable<RoleDto>>;

public class GetRolesListQueryHandler : BaseQueryHandler, IRequestHandler<GetRolesListQuery, IEnumerable<RoleDto>>
{
    public GetRolesListQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<IEnumerable<RoleDto>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Name 
            FROM AspNetRoles";

        return await QueryAsync<RoleDto>(sql);
    }
}
