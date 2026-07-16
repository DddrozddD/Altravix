using Altavix.Application.Features.Users.DTOs;
using Altavix.Application.Interfaces;
using MediatR;

namespace Altavix.Application.Features.Users.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto?>;

public class GetUserByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public GetUserByIdQueryHandler(IDbConnectionFactory connectionProvider) : base(connectionProvider)
    {
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id, 
                UserName, 
                Email, 
                FirstName, 
                LastName 
            FROM AspNetUsers 
            WHERE Id = @Id";

        return await QueryFirstOrDefaultAsync<UserDto>(sql, new { request.Id });
    }
}
