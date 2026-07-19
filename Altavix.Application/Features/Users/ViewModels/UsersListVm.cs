using Altavix.Application.Features.Users.DTOs;

namespace Altavix.Application.Features.Users.ViewModels;

public class UsersListVm
{
    public IList<UserDto> Users { get; set; } = new List<UserDto>();
}
