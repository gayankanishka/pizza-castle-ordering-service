using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaCastle.OrderingService.Application;

/// <summary>
/// Dependency injection extension to configure Application layer services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Configure Application layer services.
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}