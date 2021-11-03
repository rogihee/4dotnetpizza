using Microsoft.Extensions.DependencyInjection;

namespace PizzaCore;

public static class PizzaCoreServiceExtensions
{
    public static IServiceCollection AddPizzaCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<PizzaCoreService>();
        services.AddSingleton<IPizzaHub, PizzaHub>();
        return services;
    }
}