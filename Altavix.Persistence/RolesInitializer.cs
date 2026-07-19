using Altavix.Domain;
using Microsoft.AspNetCore.Identity;

namespace Altavix.Persistence;

public static class RolesInitializer
{
    public static async Task InitializeAsync(RoleManager<RoleEntity> roleManager)
    {
        var roles = new[] { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new RoleEntity { Name = role });
            }
        }
    }
}
