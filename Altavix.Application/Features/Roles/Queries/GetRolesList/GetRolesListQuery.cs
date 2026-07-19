using Altavix.Application.Features.Roles.ViewModels;
using MediatR;

namespace Altavix.Application.Features.Roles.Queries.GetRolesList;

public record GetRolesListQuery : IRequest<RolesListVm>;
