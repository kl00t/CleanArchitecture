using CleanArchitecture.Application;
using CleanArchitecture.Core;
using CleanArchitecture.Infrastructure;

namespace CleanArchitecture.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDependencyInjection()
            .AddInfrastructureDependencyInjection()
            .AddCoreDependencyInjection(configuration);

        return services;
    }
}