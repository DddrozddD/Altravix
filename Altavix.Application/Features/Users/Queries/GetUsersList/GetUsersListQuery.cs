using Altavix.Application.Features.Users.ViewModels;
using MediatR;

namespace Altavix.Application.Features.Users.Queries.GetUsersList;

public record GetUsersListQuery : IRequest<UsersListVm>;
