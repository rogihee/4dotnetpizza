using Microsoft.AspNetCore.SignalR;

namespace PizzaCore.Hubs;

public class PizzaHub : Hub<IPizzaHub>, IPizzaHub
{
    private readonly ILogger<PizzaHub> _logger;

    public PizzaHub(ILogger<PizzaHub> logger)
    {
        _logger = logger;
    }
    
    public Task SonderAngebot(int id, double discount)
    {
        _logger.LogInformation($"SonderAngebot! {id} {discount}");
        return Clients.All.SonderAngebot(id, discount);
    }
}