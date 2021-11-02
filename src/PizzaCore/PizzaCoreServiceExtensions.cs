
using Microsoft.Extensions.DependencyInjection;
using PizzaCore.Services;

namespace PizzaCore;

public static class PizzaCoreServiceExtensions
{
    public static IServiceCollection AddPizzaCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<PizzaCoreService>();
        //services.AddGovernanceModelServices();

        //services.AddSingleton<GovernanceHub>();
        //services.AddSingleton<GovernanceHubService>();
        //services.AddSingleton<GovernanceCoreService>();
        return services;
    }
}