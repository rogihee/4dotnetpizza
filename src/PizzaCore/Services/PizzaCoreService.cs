using Microsoft.Extensions.Logging;

namespace PizzaCore.Services
{
    public class PizzaCoreService
    {
        private readonly ILogger _logger;

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

        public PizzaCoreService(ILogger<PizzaCoreService> logger)
        {
            _logger = logger;
        }

        public Task<List<Pizza>?> GetList()
        {
            return Task.FromResult(_pizzas)!;
        }
    }
}
