using Altavix.Application.Features.Users.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Users.Queries.GetUsersList;

public record GetUsersListQuery : IRequest<IEnumerable<UserDto>>;

public class GetUsersListQueryHandler : BaseQueryHandler, IRequestHandler<GetUsersListQuery, IEnumerable<UserDto>>
{
    public GetUsersListQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                UserName, 
                Email, 
                FirstName, 
                LastName 
            FROM AspNetUsers";

        return await QueryAsync<UserDto>(sql);
    }
}
