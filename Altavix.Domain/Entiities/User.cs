using Microsoft.AspNetCore.Identity;

namespace Altavix.Domain;

public class UserEntity : IdentityUser<Guid>
{ 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}