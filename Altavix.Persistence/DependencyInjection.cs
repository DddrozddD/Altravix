using Altavix.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Altavix.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connStr = configuration["ConnectStr"];
        services.AddDbContext<AltavixDbContext>(options =>
        {
            options.UseSqlServer(connStr);
        });

        services.AddScoped<IAltavixDbContext>(provider =>
            (IAltavixDbContext)provider.GetService<AltavixDbContext>());
            
        services.AddScoped<Altavix.Domain.Repositories.IUnitOfWork, Repositories.UnitOfWork>();
        
        services.AddScoped<Altavix.Application.Interfaces.IAuthService, Services.AuthService>();
        
        return services;
    }
}