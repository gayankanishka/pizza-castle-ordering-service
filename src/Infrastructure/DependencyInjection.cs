using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaCastle.OrderingService.Infrastructure.Persistence;

namespace PizzaCastle.OrderingService.Infrastructure;

/// <summary>
/// Dependency injection extension to configure Infrastructure layer services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Configure Infrastructure layer services.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        var isInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");

        if (isInMemoryDatabase)
        {
            services.AddDbContextPool<ApplicationDbContext>(_ =>
                _.UseInMemoryDatabase("MenuServiceDb"));
        }
        else
        {
            services.AddDbContextPool<ApplicationDbContext>(_ =>
                _.UseNpgsql(
                    configuration.GetConnectionString("PostgresDbConnection"),
                    a =>
                        a.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        
        return services;
    }
}