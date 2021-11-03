using System.Timers;
using Microsoft.AspNetCore.SignalR;
using Timer = System.Timers.Timer;

namespace PizzaCore.Services;

public class PizzaCoreService
{
    private readonly ILogger _logger;
    private readonly Random _random = new();
    private readonly IHubContext<PizzaHub, IPizzaHub> _hubContext;

    private readonly List<Pizza> _pizzas = new()
    {
        new()
        {
            Id = 1, 
            Name = "Margherita",
            Ingredients = "Cheese, more cheese and tomato sauce", 
            AvailableSince = new DateTime(2020, 1, 1), 
            Price = 9.90
        },
        new()
        {
            Id = 2,
            Name = "Caprese",
            Ingredients = "Something else with cheese and tomato sauce",
            AvailableSince = new DateTime(2020, 12, 4),
            Price = 11.25
        },
        new()
        {
            Id = 3,
            Name = "Funghi",
            Ingredients = "Mushrooms and tomato sauce",
            AvailableSince = new DateTime(2019, 05, 21),
            Price = 12.50
        }
    };

    public PizzaCoreService(IHubContext<PizzaHub, IPizzaHub> hub, ILogger<PizzaCoreService> logger)
    {
        _hubContext = hub;
        _logger = logger;
        var timer = new Timer(5000);
        timer.Elapsed += TimerElapsed;
        // TODO: enable for special offers
        // timer.Start();
    }

    private async void TimerElapsed(object? sender, ElapsedEventArgs e)
    {
        var randomId = _random.Next(1, _pizzas.Count); // should random selection of ids
        _logger.LogInformation($"Special offer: {randomId} {_pizzas.Count}");
        await _hubContext.Clients.All.SonderAngebot(randomId, 7.99);
    }

    public Task<List<Pizza>?> GetList()
    {
        return Task.FromResult(_pizzas)!;
    }
}