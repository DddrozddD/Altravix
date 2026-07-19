using Altavix.Application.Features.Roles.DTOs;

namespace Altavix.Application.Features.Roles.ViewModels;

public class RolesListVm
{
    public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();
}
