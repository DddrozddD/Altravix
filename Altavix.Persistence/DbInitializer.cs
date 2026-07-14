using Microsoft.EntityFrameworkCore;

namespace Altavix.Persistence;

public class DbInitializer
{
    public static void Initialize(AltavixDbContext context)
    {
        context.Database.Migrate();
    }
}