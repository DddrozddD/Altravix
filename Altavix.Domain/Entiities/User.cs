using Microsoft.AspNetCore.Identity;

namespace Altavix.Domain;

public class UserEntity : IdentityUser<Guid>
{ 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}