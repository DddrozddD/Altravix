using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Altavix.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplivation(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}