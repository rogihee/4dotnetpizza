using Microsoft.Extensions.DependencyInjection;

namespace PizzaCore;

public static class PizzaCoreServiceExtensions
{
    public static IServiceCollection AddPizzaCoreServices(this IServiceCollection services)
    {
        //services.AddGovernanceModelServices();

        //services.AddSingleton<GovernanceHub>();
        //services.AddSingleton<GovernanceHubService>();
        //services.AddSingleton<GovernanceCoreService>();
        return services;
    }
}