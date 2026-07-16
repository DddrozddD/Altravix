using Altavix.Application.Features.Roles.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Roles.Queries.GetRoleById;

public record GetRoleByIdQuery(Guid Id) : IRequest<RoleDto?>;

public class GetRoleByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetRoleByIdQuery, RoleDto?>
{
    public GetRoleByIdQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                Name 
            FROM AspNetRoles 
            WHERE Id = @Id";

        return await QueryFirstOrDefaultAsync<RoleDto>(sql, new { request.Id });
    }
}
